using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.InterrogationReport
{
    public partial class InterrogationReportRepository : IInterrogationReportRepository
    {
        private readonly InterrogationReportFactory _factory;
        
        public InterrogationReportRepository(InterrogationReportFactory factory)
        {
            _factory = factory;
        }
        
        //Récupère les notes des élèves sur base de l'id de l'interro
        public List<Domain.InterrogationReport> GetById(int id)
        {
            var entities = new List<Domain.InterrogationReport>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetStudentsByInterro
            };

            command.Parameters.AddWithValue("@" + ColIdInterro, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
    }
}