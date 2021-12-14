namespace Application.UseCases.Admin.Dtos
{
    public class OutputDtoTokenAdmin
    {
        public int IdAdmin { get; set; }

        public string Token { get; set; }
        
        public OutputDtoTokenAdmin(Domain.Admin admin, string token)
        {
            IdAdmin = admin.IdAdmin;
            Token = token;
        }
    }
}