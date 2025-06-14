using System.ComponentModel.DataAnnotations;

namespace WebApiVendas.Dtos
{
    public class ProdutoDto
    {       
        public int Id { get; set; }
        
        public string Nome { get; set; }
       
        public string Descricao { get; set; }
        
        public string QuantidadeEstoque { get; set; }
        
        public string UnidadeMedida { get; set; }
       
        public double PrecoUnitario { get; set; }
    }
}
