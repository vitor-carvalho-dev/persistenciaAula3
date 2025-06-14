using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiVendas.Entidades
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        
        [StringLength(500)]
        public string Descricao { get; set; }

        [Range(0, int.MaxValue)]
        public string QuantidadeEstoque { get; set; }

        [Required]
        [StringLength(50)]
        public string UnidadeMedida { get; set; }

        [Range(0, int.MaxValue)]
        public double PrecoUnitario { get; set; }
    }
}

