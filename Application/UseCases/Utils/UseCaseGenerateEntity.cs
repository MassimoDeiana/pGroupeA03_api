using Application.UseCases.Student.Dtos;

namespace Application.UseCases.Utils
{
    public class UseCaseGenerateEntity<TIn, TOut, TGen>
    {
        public static void Execute(TIn dto)
        {
           //  var studentFromDto = Mapper.GetInstance().Map<TGen>(dto);
           //
           //  var studentFromDb = _studentRepository.Create(studentFromDto);
           //
           // Mapper.GetInstance().Map<TOut>(studentFromDb);
        }
    }
}