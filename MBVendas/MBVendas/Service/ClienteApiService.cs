using MBVendas.Model.Dtos;

namespace MBVendas.Service
{
    public class ClienteApiService
    {
        private readonly HttpClient _httpClient;

        public ClienteApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: /api/clientes
        public async Task<List<ClienteDto>> ObterClientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ClienteDto>>("api/cliente");
        }

        // GET: /api/clientes/{id}
        public async Task<ClienteDto?> ObterClientePorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClienteDto>($"api/cliente/{id}");
        }

        // POST: /api/clientes
        public async Task<bool> AdicionarClienteAsync(SalvarClienteDto cliente)
        {
            var response = await _httpClient.PostAsJsonAsync("api/cliente", cliente);
            return response.IsSuccessStatusCode;
        }

        // PUT: /api/clientes/{id}
        public async Task<bool> AtualizarClienteAsync(int id, SalvarClienteDto cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/cliente/{id}", cliente);
            return response.IsSuccessStatusCode;
        }

        // DELETE: /api/clientes/{id}
        public async Task<bool> ExcluirClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/cliente/{id}");
            return response.IsSuccessStatusCode;
        }

        // GET: /api/clientes/buscar?termo={termo}
        public async Task<List<ClienteDto>> PesquisarClientesAsync(string termo)
        {
            return await _httpClient.GetFromJsonAsync<List<ClienteDto>>($"api/cliente/buscar?termo={Uri.EscapeDataString(termo)}");
        }

        // GET: /api/clientes/email/{email}
        public async Task<ClienteDto?> ObterClientePorEmailAsync(string email)
        {
            return await _httpClient.GetFromJsonAsync<ClienteDto>($"api/cliente/email/{Uri.EscapeDataString(email)}");
        }

        // GET: /api/clientes/cpf/{cpf}
        public async Task<ClienteDto?> ObterClientePorCpfAsync(string cpf)
        {
            return await _httpClient.GetFromJsonAsync<ClienteDto>($"api/clientes/cpf/{cpf}");
        }

        // GET: /api/clientes/existe/email/{email}
        public async Task<bool> ExisteClientePorEmailAsync(string email)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiExisteResponse>($"api/clientes/existe/email/{Uri.EscapeDataString(email)}");
            return response?.Existe ?? false;
        }

        // GET: /api/clientes/existe/cpf/{cpf}
        public async Task<bool> ExisteClientePorCpfAsync(string cpf)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiExisteResponse>($"api/clientes/existe/cpf/{cpf}");
            return response?.Existe ?? false;
        }

        // Classe interna para capturar a resposta JSON dos endpoints de verificação
        private class ApiExisteResponse
        {
            public bool Existe { get; set; }
        }
    }
}
