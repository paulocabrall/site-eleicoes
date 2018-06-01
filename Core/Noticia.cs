using System;
using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class Noticia
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public int CandidatoNumero { get; set; }
        public string Conteudo { get; set; }
       
    }
    
}