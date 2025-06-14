using System.ComponentModel.DataAnnotations;

namespace WebApiVendas.Dtos
{
    public class SalvarProduto
    {
        
        [Required(ErrorMessage = "O Nome do produto é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Nome do produto deve ter no máximo 200 caracteres.")]        
        public string Nome { get; set; }
        
        [StringLength(500, ErrorMessage = "A Descrição deve ter no máximo 500 caracteres.")]        
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade em Estoque deve ser um valor igual ou maior que zero.")]       
        public int QuantidadeEstoque { get; set; }

        
        [Required(ErrorMessage = "A Unidade de Medida é obrigatória.")]
        [StringLength(50, ErrorMessage = "A Unidade de Medida deve ter no máximo 50 caracteres.")]       
        public string UnidadeMedida { get; set; }

        
        [Required(ErrorMessage = "O Preço Unitário é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço Unitário deve ser um valor maior que zero.")]
             
        public decimal PrecoUnitario { get; set; }
    }
}
