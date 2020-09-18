using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ToDoApp.Models;

namespace ToDoApp
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("User"))
            {
                var userInfo = await _storageService.GetItemAsync<LocalUserInfo>("User");
                var claims = new[]
                {
                    new Claim("Email", userInfo.Email),
                    new Claim("Firstname", userInfo.FirstName),
                    new Claim("LastName", userInfo.LastName),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.Id),
                    new Claim("AccessToken", userInfo.AccessToken)
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                //notify view about authorization state changed
          
                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return state;
            }

            return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());
        }

        //removes user object from the browser and notifies a view about authentication state changed
        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
