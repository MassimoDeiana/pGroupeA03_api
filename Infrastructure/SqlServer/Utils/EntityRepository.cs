using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Infrastructure.SqlServer.Utils
{
    public abstract class EntityRepository<T> : IEntityRepository<T>
    {
        private readonly IDomainFactory<T> _factory;

        private readonly string _tableName;

        private List<string> _tableColumns = new List<string>();

        protected EntityRepository(IDomainFactory<T> factory, string tableName)
        {
            _factory = factory;
            _tableName = tableName;
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
                Console.WriteLine(rowColumn[3].ToString());
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
        
        public T GetById(string request, int id, string col)
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

        public T Create(T t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var text = $@"INSERT INTO {_tableName}(";
            foreach (var column in _tableColumns.Skip(1))
            {
                if (column == _tableColumns.Last())
                {
                    text += $@"{column})
                        OUTPUT INSERTED {_tableColumns[0]}
                        VALUES";
                }
                else
                {
                    text += $@"{column}, ";
                }
            }

            foreach (var column in _tableColumns.Skip(1))
            {
                if (column == _tableColumns.Last())
                {
                    text += $@"{column})";
                }
                else
                {
                    text += $@"@{column}, ";
                }
            }

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = text
            };

            foreach (var column in _tableColumns.Skip(1))
            {
               // command.Parameters.AddWithValue("@" + column, t.column);
            }
            Console.WriteLine(t.GetType());
            var type = t.GetType();
            var properties = type.GetProperties();
            Console.WriteLine(properties[1].Name);
            /*foreach (var property in t.GetType().GetProperties())
            {
                // Gets the first attribute of type ColumnAttribute for the property
                // As you defined AllowMultiple as true, you should loop through all attributes instead.
                var attribute = property.GetCustomAttributes(false).OfType<ColumnAttribute>().FirstOrDefault();
                if (attribute != null)
                {
                    Console.WriteLine(attribute.Name);    // Prints AGE_FIELD
                }
            }*/

            //t.Id = (int) command.ExecuteScalar();
            

            return t;
        }

        public bool Delete(string request, int id, string col)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = request
            };
            
            command.Parameters.AddWithValue("@" + col, id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}