using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository : EntityRepository<Domain.Student>, IStudentRepository
    {
        private readonly StudentFactory _factory;
        
        public StudentRepository(StudentFactory factory) : base(factory)
        {
            _factory = factory;
        }

        public override Domain.Student Create(Domain.Student t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColName, t.Name);
            command.Parameters.AddWithValue("@" + ColFirstname, t.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthdate, t.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + ColPassword, t.Password);
            command.Parameters.AddWithValue("@" + ColIdClass, t.IdClass);

            t.IdStudent = (int) command.ExecuteScalar();
            
            return t;
        }

        /**
         * <summary>Modifie la classe de l'élève</summary>
         * <param name="id">L'id de l'élève</param>
         * <param name="idClass">L'id de la classe</param>
         */
        public bool Update(int id, int idClass)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdateClass
            };
            
            command.Parameters.AddWithValue("@" + StudentRepository.ColId, id);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, idClass);

            return command.ExecuteNonQuery() > 0;
        }

        /**
         * <summary>Récupère les étudiants en fonction de la classe</summary>
         * <param name="idClass">L'id de la classe</param>
         */
        public List<Domain.Student> GetByClass(int idClass)
        {
            var entities = new List<Domain.Student>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"SELECT * FROM {TableName} WHERE {ColIdClass} = @{ColIdClass}"
            };

            command.Parameters.AddWithValue("@" + ColIdClass, idClass);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }
            return entities; 
        }
    }
}