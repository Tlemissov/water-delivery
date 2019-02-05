using System.ComponentModel.DataAnnotations;

namespace WaterDelivery.Core.Users
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
