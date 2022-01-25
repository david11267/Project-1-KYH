namespace Project_1_KYH.Models
{
    public class Consultant
    {
        public int id { get; set; }
        public bool hired { get; set; }
        public string name { get; set; }
        public int phoneNumber { get; set; }
        public string details { get; set; }

        public ICollection<Skill>? Skills { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
