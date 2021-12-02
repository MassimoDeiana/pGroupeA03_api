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
            ColPassword = "password",
            ColIdClass = "idclass";
        
        private static readonly string ReqCreate = $@"INSERT INTO {TableName}(
                    {ColName}, {ColFirstname}, {ColBirthdate}, {ColMail}, {ColPassword}, {ColIdClass}) 
                    OUTPUT INSERTED.{ColId}
                    VALUES(@{ColName}, @{ColFirstname}, @{ColBirthdate}, @{ColMail}, @{ColPassword}, @{ColIdClass})";
        
        private static readonly string ReqUpdateClass = $@"UPDATE {TableName} SET {ColIdClass} = @{ColIdClass} 
                    WHERE {ColId} = @{ColId}";
    }
}