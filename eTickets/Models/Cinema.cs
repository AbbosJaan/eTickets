using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Display (Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo is required")]
        public string Logo { get; set; }
        
        [Display (Name = "Name")]
        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema name must be between 3 and 50 chars")]
        public string Name { get; set; }
        
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema description is required")]
        public string Description { get; set; }

        //Reletionships

        public List<Movie> Movies { get; set; }

    }
}
