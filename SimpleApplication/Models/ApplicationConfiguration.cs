using System.ComponentModel.DataAnnotations;

namespace SimpleApplication.Models
{
    public class ApplicationConfiguration
    {
        [Key]
        public int ID { get; set; }
        public string ApplicationCode { get; set; }
        public int OrganizationID { get; set; }
        public int ConfigurationDefinitionID { get; set; }
        public string ConfigurationValue { get; set; }
        public DateTime? DisabledDateTime { get; set; }
    }
}
