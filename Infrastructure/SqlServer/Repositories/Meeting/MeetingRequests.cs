namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository
    {
        private const string TableName = "meeting";

        public const string ColId = "idmeeting",
            ColSubject = "subject",
            ColStart = "starttime",
            ColEnd = "endtime";

        private static readonly string ReqCreate = $"INSERT INTO {TableName}({ColSubject},{ColStart},{ColEnd}) OUTPUT INSERTED.{ColId} VALUES(@{ColSubject},@{ColStart},@{ColEnd})";
    }
}