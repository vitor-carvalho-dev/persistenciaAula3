using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiVendas.Entidades;

namespace WebApiVendas.Entidades
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime? Data { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }

        [Range(0, double.MaxValue)]
        public double Total { get; set; }

        public List<ItemVenda> ItemVendas { get; set; }
    }
}
