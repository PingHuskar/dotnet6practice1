using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Friend
    {
        [ScaffoldColumn(true)]
        [Required]
        [Display(Name ="Friend ID")]

        public int FriendID { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Friend Name Empty Not Allowed.")]
        public string FriendName { get; set; }
        [Display(Name = "Address")]
        [MaxLength(25)]
        public string Place { get; set; }
    }
}
