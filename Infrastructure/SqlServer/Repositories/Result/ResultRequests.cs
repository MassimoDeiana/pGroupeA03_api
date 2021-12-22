namespace Infrastructure.SqlServer.Repositories.Result
{
    public partial class ResultRepository
    {
        private const string TableName = "note";

        public const string ColIdStudent = "idstudent",
            ColIdInterro = "idinterro",
            ColResult = "result",
            ColTotal = "total",
            ColIdLesson = "idlesson",
            ColMessage = "message";

        private static readonly string ReqByStudent = $@"
                select {TableName}.{ColIdStudent},{TableName}.{ColIdInterro},{TableName}.{ColResult},interrogation.total, interrogation.idlesson, {TableName}.{ColMessage}
                from {TableName} inner join interrogation on {TableName}.{ColIdInterro} = interrogation.{ColIdInterro} 
                where {ColIdStudent} = @{ColIdStudent}";
    }
}