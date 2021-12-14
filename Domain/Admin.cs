using System.Text.Json.Serialization;

namespace Domain
{
    public class Admin
    {
        public int IdAdmin { get; set; }
        
        public string Mail { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
    }
}