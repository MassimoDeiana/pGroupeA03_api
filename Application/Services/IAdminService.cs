using Application.UseCases.Admin.Dtos;
using Domain;

namespace Application.Services
{
    public interface IAdminService
    {
        OutputDtoTokenAdmin Authenticate(InputDtoGenerateTokenAdmin model);
        Admin GetById(int id);
    }
}