using System;
using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class FichaLimpa
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public string Cargo { get; set; }
        
    }
    
}