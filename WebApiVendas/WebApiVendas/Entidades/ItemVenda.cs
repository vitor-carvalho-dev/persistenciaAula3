using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiVendas.Entidades;

namespace WebApiVendas.Entidades
{
    public class ItemVenda
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [ForeignKey("Venda")]
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        [Range(1, int.MaxValue)]
        public string QuantidadeProduto { get; set; }

        [Range(0.01, double.MaxValue)]
        public double PrecoUnitario { get; set; }

    }
}

