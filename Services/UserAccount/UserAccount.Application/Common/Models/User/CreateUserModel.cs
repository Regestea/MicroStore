using System.ComponentModel.DataAnnotations;

namespace UserAccount.Application.Common.Models.User
{
    public class CreateUserModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
