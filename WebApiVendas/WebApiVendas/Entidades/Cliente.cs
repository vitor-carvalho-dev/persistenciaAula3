using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.SqlServer.Server;

namespace WebApiVendas.Entidades
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]        
        public string Senha { get; set; }
    }
}
