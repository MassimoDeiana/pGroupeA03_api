using System.Collections.Generic;   
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Utils
{
    /**
     * <summary>Classe abstraite automatisant les méthodes GetAll, GetById et Delete. Il faudra toutefois implémenter la méthode Create dans chaque sous-classe concrète</summary>
     */
    public abstract class EntityRepository<T> : IEntityRepository<T>
    {
        private readonly IDomainFactory<T> _factory;

        private readonly string _tableName;

        private readonly List<string> _tableColumns = new();

        protected EntityRepository(IDomainFactory<T> factory)
        {
            _factory = factory;
            // recherche du nom de la table
            _tableName = typeof(T).Name.ToLower();
            FillTableColumns();
        }

        /**
         * <summary>Méthode remplissant la variable contenant les colonnes en fonction de la table donnée</summary>
         */
        private void FillTableColumns()
        {
            using var connection = Database.GetConnection();
            connection.Open();
            // recherche des colonnes appartenant à la table
            var restrictionsColumns = new string[4];
            restrictionsColumns[2] = _tableName;
            var schemaColumns = connection.GetSchema("Columns", restrictionsColumns);
            // ajout de chaque table à la liste
            foreach (DataRow rowColumn in schemaColumns.Rows)
            {
                _tableColumns.Add(rowColumn[3].ToString());
            }
        }

        /**
         * <summary>GetAll générique renvoyant la liste des enregistrements contenus dans la table</summary>
         * <returns>Les enregistrements de la table</returns>
         */
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
        
        /**
         * <summary>GetById générique renvoyant l'enregistrement contenu dans la table ayant l'id spécifié en argument</summary>
         * <param name="id">L'id de l'enregistrement à chercher dans la table</param>
         * <returns>L'enregistrement si l'id existe</returns>
         */
        public T GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"SELECT * FROM {_tableName} WHERE {_tableColumns[0]} = @{_tableColumns[0]}"
            };
            
            // _tableColumns[0] correspond à l'id de la table
            command.Parameters.AddWithValue("@" + _tableColumns[0], id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return reader.Read() ? _factory.CreateFromSqlReader(reader) : default;
        }

        /**
         * <summary>Méthode abstraite à redéfinir par les classes concrêtes héritant de cette classe</summary>
         * <param name="t">L'objet à créer</param>
         * <returns>L'objet après création dans la base de données</returns>
         */
        public abstract T Create(T t);

        /**
         * <summary>Delete générique retirant l'enregistrement contenu dans la table ayant l'id spécifié dans la table</summary>
         * <returns>vrai si supprimé, sinon faux</returns>
         */
        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"DELETE FROM {_tableName} WHERE {_tableColumns[0]} = @{_tableColumns[0]}"
            };

            // _tableColumns[0] correspond à l'id de la table
            command.Parameters.AddWithValue("@" + _tableColumns[0], id);
            
            return command.ExecuteNonQuery() > 0;
        }
    }
}