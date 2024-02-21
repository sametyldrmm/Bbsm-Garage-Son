using System.ComponentModel.DataAnnotations;

namespace Bbsm_Garage_Son.Models
{
    public class LoginModel
    {
        [Required]
        public string? Mail { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool Remember { get; set; }
    }

}
