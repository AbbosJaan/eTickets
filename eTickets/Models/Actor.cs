using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        //Reletionships

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
