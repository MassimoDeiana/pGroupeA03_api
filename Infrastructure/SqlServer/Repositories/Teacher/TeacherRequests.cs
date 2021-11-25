namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public partial class TeacherRepository
    {
        public const string TableName = "teacher";

        public const string ColId = "idteacher",
            ColName = "name",
            ColFirstName = "firstname",
            ColBirthDate = "birthdate",
            ColMail = "mail",
            ColPassword = "password";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreate = $@"INSERT INTO {TableName}({ColName}, {ColFirstName}, {ColBirthDate}, {ColMail}, {ColPassword}) OUTPUT INSERTED.{ColId} 
            VALUES(@{ColName}, @{ColFirstName}, @{ColBirthDate}, @{ColMail}, @{ColPassword})";

        public static readonly string ReqGetById = $"SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";

        public static readonly string ReqUpdate = $"update {TableName} SET {ColName} = @{ColName}, {ColFirstName} = @{ColFirstName}, " +
                                                  $"{ColBirthDate} = @{ColBirthDate}, {ColMail} = @{ColMail}, {ColPassword} = @{ColPassword}  WHERE {ColId} = @{ColId}";

        public static readonly string ReqDelete = $"DELETE FROM {TableName} WHERE {ColId} = @{ColId}";

    }
}