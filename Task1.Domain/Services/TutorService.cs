using Microsoft.Extensions.Logging;
using Task1.Domain.Dtos.Tutor;
using Task1.Domain.Interfaces.Base;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Interfaces.IServices;
using Task1.Domain.Models;

namespace Task1.Domain.Services;

public class TutorService : ApplicationService<Tutor, long, TutorRequestDto, TutorResponseDto, TutorService>, ITutorService
{
    private TutorService(ITutorRepository tutorRepository, IUnitOfWork unitOfWork, ILogger<TutorService> logger)
        : base(tutorRepository, unitOfWork, logger)
    {
    }

    internal static TutorService CreateInstance(ITutorRepository tutorRepository, IUnitOfWork unitOfWork, ILogger<TutorService> logger)
    {
        return new TutorService(tutorRepository, unitOfWork, logger);
    }
}
