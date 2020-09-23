using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Shared.Models
{
    public class PlanRequest
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public System.IO.Stream CoverFile { get; set; }

        public string CoverPath { get; set; }

        public string FileName { get; set; }
    }
}
