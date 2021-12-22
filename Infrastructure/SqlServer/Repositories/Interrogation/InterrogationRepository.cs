using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public partial class InterrogationRepository : EntityRepository<Domain.Interrogation>, IInterrogationRepository
    {
        public InterrogationRepository(InterrogationFactory factory) : base(factory)
        {
        }

        public override Domain.Interrogation Create(Domain.Interrogation t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColIdLesson, t.IdLesson);
            command.Parameters.AddWithValue("@" + ColIdTeacher, t.IdTeacher);
            command.Parameters.AddWithValue("@" + ColSubject, t.Subject);
            command.Parameters.AddWithValue("@" + ColTotal, t.Total);

            t.IdInterro = (int) command.ExecuteScalar();

            return t;
        }

        /**
         * <summary>Méthode permettant de récupérer toutes les interrogations d'un professeur</summary>
         * <param name="id">L'id du professeur</param>
         */
        public List<Domain.Interrogation> GetByTeacher(int id)
        {
            var entities = new List<Domain.Interrogation>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetByTeacher
            };

            command.Parameters.AddWithValue("@" + ColIdTeacher, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            var factory = new InterrogationFactory();
            while (reader.Read())
            {
                entities.Add(factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
    }
}