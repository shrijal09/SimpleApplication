using System.ComponentModel.DataAnnotations;

namespace SimpleApplication.Models
{
    public class ConfigurationDefinition
    {
        [Key]
        public int ID { get; set; }
        public string ConfigurationType { get; set; }
        public string? ConfigurationDescription { get; set; }
        public string? DefaultValue { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int LastUpdateUserID { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
    }
}
