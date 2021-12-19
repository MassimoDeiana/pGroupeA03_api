namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public partial class InterrogationRepository
    {
        private const string TableName = "interrogation";

        public const string ColId = "idinterro",
            ColIdTeacher = "idteacher",
            ColIdLesson = "idlesson",
            ColSubject = "subject",
            ColTotal = "total";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdTeacher},{ColIdLesson}, {ColSubject}, {ColTotal}) OUTPUT INSERTED.{ColId} 
                    VALUES(@{ColIdTeacher}, @{ColIdLesson}, @{ColSubject}, @{ColTotal})";

        private static readonly string ReqGetByTeacher = $@"SELECT * FROM {TableName} WHERE {ColIdTeacher} = @{ColIdTeacher}";
    }
}