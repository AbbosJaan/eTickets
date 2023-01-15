using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }


        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Bio must be between 3 and 50 chars")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Reletionships

        public List<Movie> Movies { get; set; }

    }
}
