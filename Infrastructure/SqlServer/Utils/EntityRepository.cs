using System.Collections.Generic;   
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Utils
{
    public abstract class EntityRepository<T> : IEntityRepository<T>
    {
        private readonly IDomainFactory<T> _factory;

        private readonly string _tableName;

        private readonly List<string> _tableColumns = new();

        //private List<object> _data;

        protected EntityRepository(IDomainFactory<T> factory)
        {
            _factory = factory;
            _tableName = typeof(T).Name.ToLower();
            FillTableColumns();
        }

        /**
         * Méthode remplissant la variable contenant les colonnes en fonction de la table donnée
         */
        private void FillTableColumns()
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var restrictionsColumns = new string[4];
            restrictionsColumns[2] = _tableName;
            var schemaColumns = connection.GetSchema("Columns", restrictionsColumns);

            foreach (DataRow rowColumn in schemaColumns.Rows)
            {
                _tableColumns.Add(rowColumn[3].ToString());
            }
        }

        public List<T> GetAll()
        {
            var entities = new List<T>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"SELECT * FROM {_tableName}"
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
        
        public T GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"SELECT * FROM {_tableName} WHERE {_tableColumns[0]} = @{_tableColumns[0]}"
            };

            command.Parameters.AddWithValue("@" + _tableColumns[0], id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return reader.Read() ? _factory.CreateFromSqlReader(reader) : default;
        }

        public abstract T Create(T t);

        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"DELETE FROM {_tableName} WHERE {_tableColumns[0]} = @{_tableColumns[0]}"
            };

            command.Parameters.AddWithValue("@" + _tableColumns[0], id);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}