namespace Domain
{
    public class InterrogationReport
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