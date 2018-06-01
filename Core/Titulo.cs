using System;
using System.ComponentModel.DataAnnotations;

namespace banze.Core
{
    public class Titulo
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [Required]
        public int NumTitulo { get; set; }
        
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string Municipio { get; set; }
        public string DtEmissao { get; set; }
        public Boolean TituloDigital { get; set; }
    }
    
}