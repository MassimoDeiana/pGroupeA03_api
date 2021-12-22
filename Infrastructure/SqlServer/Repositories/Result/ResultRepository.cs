using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Repositories.Result
{
    public partial class ResultRepository : IResultRepository
    {
        private readonly ResultFactory _factory;
        
        public ResultRepository(ResultFactory factory)
        {
            _factory = factory;
        }

        /**
         * <summary>Récupère les notes de l'élève</summary>
         * <param name="id">L'id de l'élève</param>
         */
        public List<Domain.ResultReport> GetById(int id)
        {
            var entities = new List<Domain.ResultReport>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqByStudent
            };

            command.Parameters.AddWithValue("@" + ColIdStudent, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
    }
}