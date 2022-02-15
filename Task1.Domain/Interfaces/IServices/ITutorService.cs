using Task1.Domain.Dtos.Tutor;

namespace Task1.Domain.Interfaces.IServices;

public interface ITutorService : IApplicationService<TutorRequestDto, TutorResponseDto>, IDisposable
{

}

