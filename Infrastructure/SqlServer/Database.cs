using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Infrastructure.SqlServer
{
    public class Database
    {
        private const string FileName = @"..\connection.txt";

        private static string _connectionString; // = "Server=PORTABLE_ALLAN;Database=dbgroupeA03;Integrated Security=SSPI";
        
        public static SqlConnection GetConnection()
        {
            using (var streamReader = File.OpenText(FileName))
            {
                var text = streamReader.ReadToEnd();
                _connectionString = text;
            }
            
            return new SqlConnection(_connectionString);
        } 
    }
}