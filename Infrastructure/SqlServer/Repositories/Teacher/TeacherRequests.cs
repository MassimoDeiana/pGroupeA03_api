namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public partial class TeacherRepository
    {
        private const string TableName = "teacher";

        public const string ColId = "idteacher",
            ColName = "name",
            ColFirstName = "firstname",
            ColBirthDate = "birthdate",
            ColMail = "mail",
            ColPassword = "password";

        private static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColName}, {ColFirstName}, {ColBirthDate}, {ColMail}, {ColPassword}) OUTPUT INSERTED.{ColId} 
                    VALUES(@{ColName}, @{ColFirstName}, @{ColBirthDate}, @{ColMail}, @{ColPassword})";

    }
}