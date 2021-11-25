namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository
    {
        public const string TableName = "student";

        public const string ColId = "idstudent",
            ColName = "name",
            ColFirstname = "firstname",
            ColBirthdate = "birthdate",
            ColMail = "mail",
            ColIdClass = "idclass";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreate = $"INSERT INTO {TableName}({ColName}, {ColFirstname}, {ColBirthdate}, {ColMail}, {ColIdClass}) OUTPUT INSERTED.{ColId} " +
                                                  $"VALUES(@{ColName}, @{ColFirstname}, @{ColBirthdate}, @{ColMail}, @{ColIdClass})";

        public static readonly string ReqGetById = $"SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";

        public static readonly string ReqUpdate = $"update {TableName} SET {ColName} = @{ColName}, {ColFirstname} = @{ColFirstname}, " +
                                                  $"{ColBirthdate} = @{ColBirthdate}, {ColMail} = @{ColMail}, {ColIdClass} = @{ColIdClass} " +
                                                  $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqDelete = $"DELETE FROM {TableName} WHERE {ColId} = @{ColId}";
    }
}