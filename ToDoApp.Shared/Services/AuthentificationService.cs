using System;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using ToDoApp.Shared.Models;

namespace ToDoApp.Shared.Services
{
    public class AuthentificationService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public AuthentificationService(string url)
        {
            _baseUrl = url;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            var response = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/auth/register", request);
            return response.Result;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var response = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/auth/login", request);
            return response.Result;
        }
    }
}