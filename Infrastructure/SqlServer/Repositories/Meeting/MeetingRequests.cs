namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository
    {
        public const string TableName = "meeting";

        public const string ColId = "idmeeting",
            ColSubject = "subject";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreate = $"INSERT INTO {TableName}({ColSubject}) OUTPUT INSERTED.{ColId} VALUES(@{ColSubject})";

        public static readonly string ReqGetById = $"SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";
        
        public static readonly string ReqDelete = $"DELETE FROM {TableName} WHERE {ColId} = @{ColId}";

    }
}