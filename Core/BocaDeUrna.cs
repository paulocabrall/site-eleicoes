using System;
using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class BocaDeUrna
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public string Cargo { get; set; }
        
    }
    
}