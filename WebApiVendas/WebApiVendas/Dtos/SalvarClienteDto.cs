using System.ComponentModel.DataAnnotations;

namespace WebApiVendas.Dtos
{
    public class SalvarClienteDto
    {       

        [Required(ErrorMessage = "Nome é Obrigatorio")]
        [StringLength(100, ErrorMessage = "No maximo 100 caracteres")]
        
        public string? Nome { get; set; }

        
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
        [RegularExpression(@"^\d{11}", ErrorMessage = "CPF deve conter apenas numeros")]
        public string? Cpf { get; set; }

     
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string? Email { get; set; }
        
        
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A Senha deve ter entre 6 e 100 caracteres.")]
        public string? Senha { get; set; }
    }
}
