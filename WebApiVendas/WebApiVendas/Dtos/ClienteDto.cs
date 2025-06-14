using System.ComponentModel.DataAnnotations;

namespace WebApiVendas.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }

        
        public string Nome { get; set; }

        
        public string Cpf { get; set; }

       
        public string Email { get; set; }

        
    }
}
