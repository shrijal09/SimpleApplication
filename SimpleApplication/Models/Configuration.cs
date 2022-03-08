using System.ComponentModel.DataAnnotations;

namespace SimpleApplication.Models
{
    public class Configuration
    {
        [Key]
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
        public string Application { get; set; }
    }
}
