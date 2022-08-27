using System.ComponentModel.DataAnnotations;

namespace UserAccount.API.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public Address Address { get; set; }
    }
}
