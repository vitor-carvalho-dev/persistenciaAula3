using System.ComponentModel.DataAnnotations;

namespace MBVendas.ViewModel
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 100 caracteres")]
        public string? Senha { get; set; }

        public bool IsEdicao { get; set; } = false;

        public string TituloFormulario { get; set; } = string.Empty;
        public string TextoBotao { get; set; } = string.Empty;
    }
}
