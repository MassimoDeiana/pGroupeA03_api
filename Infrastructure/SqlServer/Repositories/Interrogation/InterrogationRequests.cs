namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public partial class InterrogationRepository
    {
        private const string TableName = "interrogation";

        public const string ColId = "idinterro",
            ColIdCourse = "idcourse",
            ColSubject = "subject",
            ColTotal = "total";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColIdCourse}, {ColSubject}, {ColTotal}) OUTPUT INSERTED.{ColId} 
                    VALUES(@{ColIdCourse}, @{ColSubject}, @{ColTotal})";
    }
}