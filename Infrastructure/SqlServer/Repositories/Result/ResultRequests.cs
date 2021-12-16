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
    }
}