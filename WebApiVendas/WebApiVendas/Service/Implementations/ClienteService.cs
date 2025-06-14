using Microsoft.EntityFrameworkCore;
using WebApiVendas.Data.Context;
using WebApiVendas.Dtos;
using WebApiVendas.Entidades;
using WebApiVendas.Service.Interface;

namespace WebApiVendas.Service.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly SQLServerContext _context;

        public ClienteService(SQLServerContext context)
        {
            _context = context;
        }        

        public async Task<ClienteDto> AdicionarClienteAsync(SalvarClienteDto clienteDto)
        {
            if (string.IsNullOrWhiteSpace(clienteDto.Senha))
            {
                throw new ArgumentNullException("Senha é obrigatoria para criar");
            }
            var cliente = new Cliente
            {
                Nome = clienteDto.Nome.Trim(),
                Cpf = clienteDto.Cpf.Trim(),
                Email = clienteDto.Email.Trim().ToLowerInvariant(),
                Senha = clienteDto.Senha
            };
            
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Email = cliente.Email,
            };
        }

        public async Task<bool> AtualizarClienteAsync(int idCliente, SalvarClienteDto clienteDto)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);
            if (cliente == null)
            {
                return false;
            }
            cliente.Nome = clienteDto.Nome.Trim();
            cliente.Cpf = clienteDto.Cpf.Trim();
            cliente.Email = clienteDto.Email.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(clienteDto.Senha))
            {
                throw new ArgumentNullException("Senha é obrigatória para criar");
            }
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> ExcluirClienteAsync(int idCliente)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);
            if (cliente == null)
            {
                return false;
            }
            
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> JaExisteCpfAsync(string cpf)
        {

            return await _context.Clientes.AnyAsync(c => c.Cpf == cpf);
        }

        public async Task<bool> JaExisteEmailAsync(string email)
        {
            return await _context.Clientes.AnyAsync(c => c.Email.ToLower() == email.ToLower());
        }

        public async Task<List<ClienteDto>> ObterClienteAsync()
        {
            return await _context.Clientes
                    .OrderBy(c => c.Nome) 
                    .Select(c => new ClienteDto
                    {                        
                        IdCliente = c.IdCliente,
                        Nome = c.Nome,
                        Cpf = c.Cpf,
                        Email = c.Email
                    })
                    .ToListAsync(); 
                    }

        public async Task<ClienteDto?> ObterClientePorCpfAsync(string cpf)
        {
            return await _context.Clientes
                              .Where(c => c.Cpf == cpf)                              
                              .Select(c => new ClienteDto
                              {
                                  IdCliente = c.IdCliente,
                                  Nome = c.Nome,
                                  Cpf = c.Cpf,
                                  Email = c.Email
                              })
                              .FirstOrDefaultAsync();
        }

        public async Task<ClienteDto?> ObterClientePorEmailAsync(string email)
        {
            
            return await _context.Clientes
                .Where(c => c.Email.ToLower() == email.ToLower())
                .Select(c => new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    Email = c.Email
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ClienteDto?> ObterClientePorIdAsync(int idCliente)
        {
            return await _context.Clientes
                              .Where(c => c.IdCliente == idCliente)
                              .OrderBy(c => c.Nome)
                              .Select(c => new ClienteDto
                              {
                                  IdCliente = c.IdCliente,
                                  Nome = c.Nome,
                                  Cpf = c.Cpf,
                                  Email = c.Email
                              })
                              .FirstOrDefaultAsync();
        }

        
    }
}
