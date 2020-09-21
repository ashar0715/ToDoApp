using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Shared.Models
{
    public class PlanRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public string CoverFile { get; set; }

        public string FileName { get; set; }
    }
}
