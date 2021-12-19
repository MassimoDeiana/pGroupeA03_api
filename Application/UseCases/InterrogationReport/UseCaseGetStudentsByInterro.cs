using System.Collections.Generic;
using System.Linq;
using Application.UseCases.InterrogationReport.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.InterrogationReport;

namespace Application.UseCases.InterrogationReport
{
    public class UseCaseGetStudentsByInterro : IQueryFiltering<List<OutputDtoInterrogationReport>, InputDtoGenerateInterrogationReport>
    {
        private readonly IInterrogationReportRepository _resultRepository;

        public UseCaseGetStudentsByInterro(IInterrogationReportRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        
        public List<OutputDtoInterrogationReport> Execute(InputDtoGenerateInterrogationReport dto)
        {
            var output = _resultRepository.GetById(dto.IdInterro);
            
            return output.Select(t => Mapper.GetInstance().Map<OutputDtoInterrogationReport>(t)).ToList();
        }
    }
}