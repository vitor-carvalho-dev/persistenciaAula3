using System.ComponentModel.DataAnnotations;

namespace MBVendas.Model.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Senha intencionalmente omitida por segurança
    }
    
}
