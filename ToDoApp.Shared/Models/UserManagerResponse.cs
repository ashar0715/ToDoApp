using System;
namespace ToDoApp.Shared.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string[] Errors { get; set; }
    }
}
