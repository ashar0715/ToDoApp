using System;
namespace ToDoApp.Shared.Models
{
    public class PlanCollectionResponse : BaseApiResponse
    {
        public Plan[] Records { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? NextPage { get; set; }
    }
}