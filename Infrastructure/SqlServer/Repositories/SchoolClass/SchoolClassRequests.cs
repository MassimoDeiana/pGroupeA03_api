namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public partial class SchoolClassRepository
    {
        public const string TableName = "schoolclass";

        public const string ColId = "idclass",
            ColName = "name",
            ColYear = "year",
            ColNbStudents = "nbstudent";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColYear}, {ColNbStudents})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColYear}, @{ColNbStudents})";
        
        public static readonly string ReqGetById = $@"
            SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";

        public static readonly string ReqDelete = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId}";
    }
}