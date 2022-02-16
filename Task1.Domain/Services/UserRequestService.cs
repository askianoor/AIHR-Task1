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

    public UserRequestService(IUserRequestRepository repository, IUnitOfWork unitOfWork, ILogger<UserRequestService> logger, IUserRequestCourseRepository userRequestCourseRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _userRequestCourseRepository = userRequestCourseRepository;
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
        var entity = input.Adapt<UserRequest>();

        try
        {
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
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotAdd, ex.Message);
        }

        return entity.Adapt<UserRequestResponseDto>();
    }

    public virtual async Task<UserRequestResponseDto> Update(UserRequestRequestDto input)
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

        var entity = input.Adapt<UserRequest>();

        try
        {
            await _repository.Update(entity);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotUpdate, ex.Message);

            throw new Exception(GlobalResource.CanNotUpdate);
        }

        return entity.Adapt<UserRequestResponseDto>();
    }

    public virtual async Task<bool> Remove(long id)
    {
        try
        {
            var result = await _repository.GetById(id);
            await _repository.Remove(result);
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Dispose();
            _logger.LogError(GlobalResource.CanNotDelete, ex.Message);

            return false;
        }

        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}