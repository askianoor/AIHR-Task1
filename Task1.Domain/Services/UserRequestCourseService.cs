using Mapster;
using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.UserRequestCourse;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class UserRequestCourseService : IUserRequestCourseService
{
    private readonly IUserRequestCourseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserRequestCourseService> _logger;

    public UserRequestCourseService(IUserRequestCourseRepository repository, IUnitOfWork unitOfWork, ILogger<UserRequestCourseService> logger)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<List<UserRequestCourseResponseDto>> GetByRequestId(long requestId)
    {
        var resultList = await _repository.GetByRequestId(requestId);
        return resultList.Adapt<List<UserRequestCourseResponseDto>>();
    }

    public async Task<bool> RemoveCourseFromRequest(long userRequestCourseId)
    {
        try
        {
            var result = await _repository.GetById(userRequestCourseId);
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

    public async Task<UserRequestCourseResponseDto> GetCourseState(UserRequestCourseRequestDto input)
    {
        var result = await _repository.Search(b =>
            b.UserRequestId == input.UserRequestId && b.CourseId == input.CourseId);

        return result.Adapt<UserRequestCourseResponseDto>();
    }

    public async Task<UserRequestCourseResponseDto> SetCourseState(UserRequestCourseCreateDto input)
    {
        if (!await _repository.AnyAsync(b => b.Id == input.Id))
        {
            throw new Exception(GlobalResource.CanNotFound);
        }

        var entity = input.Adapt<UserRequestCourse>();

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

        return entity.Adapt<UserRequestCourseResponseDto>();
    }
}
