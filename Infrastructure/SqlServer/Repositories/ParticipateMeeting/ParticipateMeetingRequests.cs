namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public partial class ParticipateMeetingRepository
    {
        private const string TableName = "participatemeeting";

        public const string ColIdMeeting = "idmeeting",
            ColIdTeacher = "idteacher",
            ColDate = "datemeeting";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdMeeting}, {ColIdTeacher}, {ColDate})
                                                   VALUES(@{ColIdMeeting}, @{ColIdTeacher}, @{ColDate})";
    }
}