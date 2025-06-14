using WebApiVendas.Dtos;

namespace WebApiVendas.Service.Interface
{
    public interface IClienteService
    {
        

        Task<List<ClienteDto>> ObterClienteAsync();
        Task<ClienteDto> ObterClientePorIdAsync(int idCliente);
        Task<ClienteDto> AdicionarClienteAsync(SalvarClienteDto clienteDto);       
        Task<ClienteDto> ObterClientePorEmailAsync(string email);
        Task<ClienteDto> ObterClientePorCpfAsync(string cpf);
        Task<bool> AtualizarClienteAsync(int idCliente, SalvarClienteDto clienteDto);
        Task<bool> ExcluirClienteAsync(int idCliente);
        Task<bool> JaExisteEmailAsync(string email);
        Task<bool> JaExisteCpfAsync(string cpf);

        


    }
}
