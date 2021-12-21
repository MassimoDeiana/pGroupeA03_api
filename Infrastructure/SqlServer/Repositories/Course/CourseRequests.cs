namespace Infrastructure.SqlServer.Repositories.Course
{
    public partial class CourseRepository
    {
        private const string TableName = "course";

        public const string ColId = "idcourse",
            ColIdLesson = "idlesson",
            ColStart = "starttime",
            ColEnd = "endtime",
            ColIdTeacher = "idteacher",
            ColIdClass = "idclass";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdLesson},{ColStart},{ColEnd},{ColIdTeacher},{ColIdClass}) OUTPUT INSERTED.{ColId} 
                                                    VALUES(@{ColIdLesson},@{ColStart},@{ColEnd},@{ColIdTeacher},@{ColIdClass})";
        private static readonly string ReqGetByTeacher = $@"SELECT * FROM {TableName} WHERE {ColIdTeacher} = @{ColIdTeacher}";

    }
}