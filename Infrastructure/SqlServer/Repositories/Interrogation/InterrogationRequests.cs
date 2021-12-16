namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public partial class InterrogationRepository
    {
        private const string TableName = "interrogation";

        public const string ColId = "idinterro",
            ColIdLesson = "idlesson",
            ColSubject = "subject",
            ColTotal = "total";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdLesson}, {ColSubject}, {ColTotal}) OUTPUT INSERTED.{ColId} 
                    VALUES(@{ColIdLesson}, @{ColSubject}, @{ColTotal})";
    }
}