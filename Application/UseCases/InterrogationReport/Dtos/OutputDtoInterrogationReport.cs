namespace Application.UseCases.InterrogationReport.Dtos
{
    public class OutputDtoInterrogationReport
    {
        public int IdInterro { get; set; }
        
        public int IdStudent { get; set; }
        
        public string Name { get; set; }
        
        public string FirstName { get; set; }
        
        public double Result { get; set; }
        
        public int Total { get; set; }
        
        public string Message { get; set; }
    }
}