using System;
using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class Candidato
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Partido { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
        public string Foto { get; set; }
        
    }
    
}