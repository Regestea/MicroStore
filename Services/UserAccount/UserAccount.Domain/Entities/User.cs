using System.ComponentModel.DataAnnotations;
using UserAccount.Domain.Common;

namespace UserAccount.Domain.Entities
{
    public class User : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public string? Image { get; set; }

        public Address Address { get; set; }
    }
}
