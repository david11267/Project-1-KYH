using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_1_KYH.Models
{
    public class Project
    {
        [DisplayName("ID")]
        public int id { get; set; }
        public Company Company { get; set; }
        [DisplayName("Name")]
        [Required]
        public string projectName { get; set; }
        [DisplayName("Budget")]
        public int? budget { get; set; }
        [DisplayName("Status")]
        public string? status { get; set; }
        [DisplayName("Details")]
        public string? details { get; set; }
        [DisplayName("Skills")]
        public ICollection<Skill>? Skills { get; set; }
        [DisplayName("Consultants")]
        public List<Consultant>? Consultants { get; set; }
    }
}
