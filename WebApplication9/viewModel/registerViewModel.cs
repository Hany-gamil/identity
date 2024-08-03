using System.ComponentModel.DataAnnotations;

namespace WebApplication9.viewModel
{
    public class registerViewModel
    {
        [Required]
        public string  username { get; set; }
        [DataType(DataType.Password)]
        [Required]

        public string password { get; set; }
        [DataType (DataType.Password)]
        [Compare("password")]
        [Required]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }


    }
}
