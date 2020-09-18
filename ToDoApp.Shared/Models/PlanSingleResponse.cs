using System;
namespace ToDoApp.Shared.Models
{
    public class PlanSingleResponse : BaseApiResponse
    {
        public Plan Record { get; set; }
    }
}