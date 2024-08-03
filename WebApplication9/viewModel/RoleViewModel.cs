using System.ComponentModel.DataAnnotations;

namespace WebApplication9.viewmodel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
