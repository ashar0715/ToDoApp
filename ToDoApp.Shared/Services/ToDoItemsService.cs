using System;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using ToDoApp.Shared.Models;

namespace ToDoApp.Shared.Services
{
    public class ToDoItemsService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public ToDoItemsService(string url)
        {
            _baseUrl = url;
        }

        public string AccessToken
        {
            get => client.AccessToken;
            set
            {
                client.AccessToken = value;
            }
        }

        public async Task<ToDoItemSingleResponse> CreateItemAsync(ToDoItemRequest model)
        {
            var response = await client.PostProtectedAsync<ToDoItemSingleResponse>($"{_baseUrl}/api/todoitems", model);
            return response.Result;
        }

        public async Task<ToDoItemSingleResponse> EditItemAsync(ToDoItemRequest model)
        {
            var response = await client.PutProtectedAsync<ToDoItemSingleResponse>($"{_baseUrl}/api/todoitems", model);
            return response.Result;
        }

        /// <summary>
        /// Mark item as done/undone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> ChangeItemStateAsync(string id)
        {
            var response = await client.PutProtectedAsync<ToDoItemSingleResponse>($"{_baseUrl}/api/todoitems/{id}", null);
            return response.Result;
        }

        public async Task<ToDoItemSingleResponse> DeleteItemAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<ToDoItemSingleResponse>($"{_baseUrl}/api/todoitems/{id}");
            return response.Result;
        }


    }
}
