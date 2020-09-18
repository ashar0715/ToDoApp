﻿using System;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using ToDoApp.Shared.Models;

namespace ToDoApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public PlansService(string url)
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

        /// <summary>
        /// Retrieves all the plans from API with pagination
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanCollectionResponse> GetAllPlansByPageAsync (int page = 1)
        {
            //GetProtectedAsync sends also access token
            var response = await client.GetProtectedAsync<PlanCollectionResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        /// Retrieves all the plans from API with pagination
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlanCollectionResponse> SearchPlansByPageAsync(string query, int page = 1)
        {
            //GetProtectedAsync sends also access token
            var response = await client.GetProtectedAsync<PlanCollectionResponse>($"{_baseUrl}/api/plans?query={query}&page={page}");
            return response.Result;
        }
    }
}