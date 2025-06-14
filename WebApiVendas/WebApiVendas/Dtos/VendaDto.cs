using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiVendas.Entidades;

namespace WebApiVendas.Dtos
{
    public class VendaDto
    {
        

        public DateTime? Data { get; set; }

        
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

       
        public int VendedorId { get; set; }

      
        public double Total { get; set; }

        public List<ItemVenda> ItemVendas { get; set; }
    }
}
