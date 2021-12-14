namespace Infrastructure.SqlServer.Repositories.Admin
{
    public partial class AdminRepository
    {
        private const string TableName = "admin";

        public const string ColId = "idadmin",
            ColMail = "mail",
            ColPassword = "password";
    }
}