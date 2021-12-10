namespace Infrastructure.SqlServer.Repositories.Course
{
    public partial class CourseRepository
    {
        private const string TableName = "course";

        public const string ColId = "idcourse",
            ColStart = "starttime",
            ColEnd = "endtime",
            ColSubject = "subject",
            ColIdTeacher = "idteacher",
            ColIdClass = "idclass";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColStart},{ColEnd},{ColSubject},{ColIdTeacher},{ColIdClass}) OUTPUT INSERTED.{ColId} 
                                                    VALUES(@{ColStart},@{ColEnd},@{ColSubject},@{ColIdTeacher},@{ColIdClass})";
        
    }
}