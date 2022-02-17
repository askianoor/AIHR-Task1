using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.UserRequest;
using Task1.Domain.Enums;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class UserRequestService : IUserRequestService
{
    private readonly IUserRequestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserRequestService> _logger;
    private readonly IUserRequestCourseRepository _userRequestCourseRepository;
    private readonly ICourseRepository _courseRepository;

    public UserRequestService(IUserRequestRepository repository,
                                IUnitOfWork unitOfWork,
                                ILogger<UserRequestService> logger,
                                IUserRequestCourseRepository userRequestCourseRepository,
                                ICourseRepository courseRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _userRequestCourseRepository = userRequestCourseRepository;
        _courseRepository = courseRepository;
    }

    public virtual async Task<IEnumerable<UserRequestResponseDto>> GetAll()
    {
        var categories = await _repository.GetAll();
        return categories.Adapt<IEnumerable<UserRequestResponseDto>>();
    }

    public virtual async Task<UserRequestResponseDto> GetById(long id)
    {
        var entity = await _repository.GetById(id);
        return entity.Adapt<UserRequestResponseDto>();
    }

    public virtual async Task<UserRequestResponseDto> Add(UserRequestRequestDto input)
    {
        InputDatesValidation(input);

        try
        {
            var entity = input.Adapt<UserRequest>();

            entity.TotalHourPerWeek = await CalculateTotalHoursPerWeekAsync(input);

            await _repository.AddAsync(entity);

            foreach (var userCourse in input.CourseIds
                         .Select(courseId => new UserRequestCourse
                         {
                             UserRequestId = entity.Id,
                             CourseId = courseId,
                         }))
            {
                await _userRequestCourseRepository.AddAsync(userCourse);
            }

            _unitOfWork.Commit();
            return entity.Adapt<UserRequestResponseDto>();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotAdd, ex.Message);
            throw new Exception(GlobalResource.CanNotAdd);
        }
    }



    public virtual async Task<UserRequestResponseDto> Update(UserRequestRequestDto input)
    {
        await UpdateValidation(input);

        try
        {
            var entity = input.Adapt<UserRequest>();

            entity.TotalHourPerWeek = await CalculateTotalHoursPerWeekAsync(input);

            await _repository.Update(entity);
            _unitOfWork.Commit();
            return entity.Adapt<UserRequestResponseDto>();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotUpdate, ex.Message);

            throw new Exception(GlobalResource.CanNotUpdate);
        }
    }

    public virtual async Task<bool> Remove(long id)
    {
        try
        {
            var result = await _repository.GetById(id);
            await _repository.Remove(result);
            _unitOfWork.Commit();
            return true;
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotDelete, ex.Message);

            return false;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }


    private async Task<int> CalculateTotalHoursPerWeekAsync(UserRequestRequestDto input)
    {
        var coursesTotalHours = await _courseRepository.GetCoursesTotalHours(input.CourseIds);

        var days = (input.EndDate - input.StartDate).Days;

        var hours = (coursesTotalHours / days);

        return hours;
    }

    private static void InputDatesValidation(UserRequestRequestDto input)
    {
        if (input.StartDate < input.EndDate)
        {
            throw new Exception(GlobalResource.StartDateIsGreaterThanEndDate);
        }
    }

    private async Task UpdateValidation(UserRequestRequestDto input)
    {
        if (!await _repository.AnyAsync(b => b.Id == input.Id))
        {
            throw new Exception(GlobalResource.CanNotFound);
        }

        //For Instance: Update is forbidden if the request state has changed!
        if (await _repository.AnyAsync(b => b.RequestState != RequestState.Draft))
        {
            throw new Exception(GlobalResource.CanNotUpdate);
        }

        InputDatesValidation(input);
    }
}