using System.ComponentModel.DataAnnotations;

namespace MBVendas.Model.Dtos
{
    public class SalvarClienteDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter exatamente 11 dígitos")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas números")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Email deve ter um formato válido")]
        public string Email { get; set; } = string.Empty;

        // Senha opcional no DTO - validação de obrigatoriedade fica no Service
        // POST: obrigatória (Service valida), PUT: opcional (null = não altera)
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 100 caracteres")]
        public string? Senha { get; set; }
    }
}
