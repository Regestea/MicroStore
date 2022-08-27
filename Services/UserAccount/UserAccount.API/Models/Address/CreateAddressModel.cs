using System.ComponentModel.DataAnnotations;

namespace UserAccount.API.Models.Address
{
    public class CreateAddressModel
    {
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoctionAddress { get; set; }

    }
}
