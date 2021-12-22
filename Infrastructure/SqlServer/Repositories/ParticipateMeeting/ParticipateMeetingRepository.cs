using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public partial class ParticipateMeetingRepository : EntityRepository<Domain.ParticipateMeeting>, IParticipateMeetingRepository
    {
        private readonly ParticipateMeetingFactory _factory;
        public ParticipateMeetingRepository(ParticipateMeetingFactory factory) : base(factory)
        {
            _factory = factory;
        }

        public override Domain.ParticipateMeeting Create(Domain.ParticipateMeeting t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            command.Parameters.AddWithValue("@" + ColIdMeeting, t.IdMeeting);
            command.Parameters.AddWithValue("@" + ColIdTeacher, t.IdTeacher);


            command.ExecuteScalar();
            
            return t;
        }

        /**
         * <summary>Récupère les meetings auxquels participent le professeur</summary>
         * <param name="id">L'id du professeur</param>
         */
        public new List<Domain.ParticipateMeeting> GetById(int id)
        {
            var entities = new List<Domain.ParticipateMeeting>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetByIdTeacher
            };

            command.Parameters.AddWithValue("@" + ColIdTeacher, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
    }
}