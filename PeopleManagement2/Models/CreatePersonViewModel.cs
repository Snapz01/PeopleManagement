using System.ComponentModel.DataAnnotations;

namespace PeopleManagement2.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string CityName { get; set; } = string.Empty;
    }
}