namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository
    {
        private const string TableName = "student";

        public const string ColId = "idstudent",
            ColName = "name",
            ColFirstname = "firstname",
            ColBirthdate = "birthdate",
            ColMail = "mail",
            ColIdClass = "idclass";
        
        private static readonly string ReqCreate = $"INSERT INTO {TableName}({ColName}, {ColFirstname}, {ColBirthdate}, {ColMail}, {ColIdClass}) OUTPUT INSERTED.{ColId} " +
                                                  $"VALUES(@{ColName}, @{ColFirstname}, @{ColBirthdate}, @{ColMail}, @{ColIdClass})";
    }
}