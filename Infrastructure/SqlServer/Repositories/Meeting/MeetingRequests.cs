namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository
    {
        private const string TableName = "meeting";

        public const string ColId = "idmeeting",
            ColSubject = "subject";
        
        private static readonly string ReqCreate = $"INSERT INTO {TableName}({ColSubject}) OUTPUT INSERTED.{ColId} VALUES(@{ColSubject})";
    }
}