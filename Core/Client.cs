using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class Client
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AddressComplement { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }
}