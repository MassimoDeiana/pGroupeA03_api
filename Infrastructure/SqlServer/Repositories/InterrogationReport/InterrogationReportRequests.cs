namespace Infrastructure.SqlServer.Repositories.InterrogationReport
{
    public partial class InterrogationReportRepository
    {
        private const string TableName = "note";

        public const string ColIdInterro = "idinterro",
            ColIdStudent = "idstudent",
            ColName = "name",
            ColFirstName = "firstname",
            ColResult = "result",
            ColTotal = "total",
            ColMessage = "message";

        private static readonly string ReqGetStudentsByInterro = $@"
                SELECT interrogation.{ColIdInterro},student.idstudent,student.{ColName},student.{ColFirstName},{TableName}.{ColResult},
                interrogation.total,{TableName}.{ColMessage} FROM {TableName} 
                INNER JOIN interrogation ON {TableName}.{ColIdInterro} = interrogation.{ColIdInterro} 
                INNER JOIN student ON {TableName}.{ColIdStudent} = student.{ColIdStudent}
                WHERE interrogation.{ColIdInterro} = @{ColIdInterro}";
    }
}