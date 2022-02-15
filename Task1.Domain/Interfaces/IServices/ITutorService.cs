using Task1.Domain.Dtos.Tutor;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IServices;

public interface ITutorService : IApplicationService<Tutor,long,TutorRequestDto, TutorResponseDto, ITutorService>, IDisposable
{

}

