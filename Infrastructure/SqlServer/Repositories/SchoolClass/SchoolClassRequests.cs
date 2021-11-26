namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public partial class SchoolClassRepository
    {
        private const string TableName = "schoolclass";

        public const string ColId = "idclass",
            ColName = "name",
            ColYear = "year",
            ColNbStudents = "nbstudent";

        private static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColYear}, {ColNbStudents})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColYear}, @{ColNbStudents})";
    }
}