namespace Infrastructure.SqlServer.Repositories.Course
{
    public partial class CourseRepository
    {
        public const string TableName = "course";

        public const string ColId = "idcourse",
            ColDay = "day",
            ColHour = "hour",
            ColDuration = "duration",
            ColSubject = "subject";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreate = $"INSERT INTO {TableName}({ColDay},{ColHour},{ColDuration},{ColSubject}) OUTPUT INSERTED.{ColId} VALUES(@{ColDay},@{ColHour},@{ColDuration},@{ColSubject})";

        public static readonly string ReqGetById = $"SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";
        
        public static readonly string ReqDelete = $"DELETE FROM {TableName} WHERE {ColId} = @{ColId}";

    }
}