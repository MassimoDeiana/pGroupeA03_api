namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public partial class ParticipateMeetingRepository
    {
        private const string TableName = "participatemeeting";

        public const string ColIdMeeting = "idmeeting",
            ColIdTeacher = "idteacher";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdMeeting}, {ColIdTeacher})
                                                   VALUES(@{ColIdMeeting}, @{ColIdTeacher})";

        private static readonly string ReqGetByIdTeacher =
            $"SELECT * FROM {TableName} where {ColIdTeacher} = @{ColIdTeacher}";
    }
}