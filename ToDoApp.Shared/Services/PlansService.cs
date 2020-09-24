using System;
using System.Collections.Generic;
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
        /// Retrieves a plan with the requested Id if it exists
        /// </summary>
        /// <param name="id">Id of the plan to be retrieved</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> GetPlanByIdAsync(string id)
        {
            var response = await client.GetProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans/{id}");
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
            var response = await client.GetProtectedAsync<PlanCollectionResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
            return response.Result;
        }

        /// <summary>
        /// Send a plan to api
        /// </summary>
        /// <param name="model">Represents the plan to be added</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> PostPlanAsync(PlanRequest model)
        {
            var formKeyValues = new List<FormKeyValue>()
            {
                new StringFormKeyValue("Title", model.Title),
                new StringFormKeyValue("Description", model.Description)
            };

            if (model.CoverFile != null)
            {
                formKeyValues.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));
            }

            var response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.POST,
                formKeyValues.ToArray());

            return response.Result;
        }

        /// <summary>
        /// Edit a plan
        /// </summary>
        /// <param name="model">Id of a plan to be edited</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> EditPlanAsync(PlanRequest model)
        {
            var formKeyValues = new List<FormKeyValue>()
            {
                new StringFormKeyValue("ID", model.Id),
                new StringFormKeyValue("Title", model.Title),
                new StringFormKeyValue("Description", model.Description)
            };

            if (model.CoverFile != null)
            {
                formKeyValues.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));
            }

            var response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.PUT, formKeyValues.ToArray());

            return response.Result;
        }

        /// <summary>
        /// Deletes specified plan
        /// </summary>
        /// <param name="id">Id of a plan</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> DeletePlanAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans/{id}");
            return response.Result;
        }
    }
}