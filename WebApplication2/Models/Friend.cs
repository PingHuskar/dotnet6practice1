using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Friend
    {
        [ScaffoldColumn(true)]
        [Required]
        public int FriendID { get; set; }

        [Required(ErrorMessage = "Friend Name Empty Not Allowed.")]
        public string FriendName { get; set; }

        [MaxLength(25)]
        public string Place { get; set; }
    }
}
