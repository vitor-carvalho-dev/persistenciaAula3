using Microsoft.AspNetCore.Mvc;
using WebApiVendas.Dtos;
using WebApiVendas.Entidades;
using WebApiVendas.Service.Implementations;
using WebApiVendas.Service.Interface;

namespace WebApiVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("aplication/json")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClienteDto>))]

        public async Task<ActionResult<List<ClienteDto>>> ObterClientes()
        {
            try
            {
                var clientes  = await _clienteService.ObterClienteAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno de service", error = ex.Message });
            }


        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(List<ClienteDto>))]
        [ProducesResponseType(404)]

        public async Task<ActionResult<List<ClienteDto>>> ObterClienteId(int id)
        {
            try
            {
                var clientes = await _clienteService.ObterClientePorIdAsync(id);
                if (clientes == null)
                
                    return NotFound(new { message = "Cliente nao encontrado" });
                
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno de service", error = ex.Message });
            }


        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ClienteDto>> CriarCliente([FromBody] SalvarClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cliente = await _clienteService.AdicionarClienteAsync(clienteDto);

                return CreatedAtAction(
                    nameof(ObterClienteId),
                    new { id = cliente.IdCliente },
                    cliente
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor", error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClienteDto>> AtualizarCliente(int id, [FromBody] SalvarClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                
                var sucesso = await _clienteService.AtualizarClienteAsync(id, clienteDto);

                if (!sucesso)
                {
                    return NotFound(new { message = "Cliente nao encontrado" });
                }
                return Ok(new { message = "Cliente atualizado com sucesso" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor", error = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        
        public async Task<ActionResult<ClienteDto>> ExcluirCliente(int id)
        {
            try
            {                
                var sucesso = await _clienteService.ExcluirClienteAsync(id);

                if (!sucesso)
                {
                    return NotFound(new { message = "Cliente nao encontrado" });
                }
                return Ok(new { message = "Cliente excluido com sucesso" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor", error = ex.Message });
            }
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(200, Type = typeof(ClienteDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClienteDto>> ObterClientePorEmail(string email)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorEmailAsync(email);

                if (cliente == null)
                    return NotFound(new { message = "Cliente não encontrado com este email" });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor", error = ex.Message });
            }
        }

        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(200, Type = typeof(ClienteDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClienteDto>> ObterClientePorCpf(string cpf)
        {
            try
            {
                var cliente = await _clienteService.ObterClientePorCpfAsync(cpf);

                if (cliente == null)
                    return NotFound(new { message = "Cliente não encontrado com este CPF" });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor", error = ex.Message });
            }
        }
    }
}
