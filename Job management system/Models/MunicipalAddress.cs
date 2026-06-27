using System.ComponentModel.DataAnnotations;

namespace Job_management_system.Models
{
    public class MunicipalAddress
    {
        public int Id { get; set; }

        [Display(Name ="Description",Description ="Write a description for this municipal address to explain what's located here.")]
        public String Description { get; set; }

        public int Number { get; set; }

        [Display(Name = "Street name", Description = "Write the name of the street.")]
        public String StreetName { get; set; }

        public String City { get; set; }
        public String Province { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
