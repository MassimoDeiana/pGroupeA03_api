namespace Domain
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public byte Year { get; set; }
        
        public int NbStudents { get; set; }

        public SchoolClass(string name, byte year, int nbStudents)
        {
            Name = name;
            Year = year;
            NbStudents = nbStudents;
        }

        public SchoolClass()
        {
        }
    }
}