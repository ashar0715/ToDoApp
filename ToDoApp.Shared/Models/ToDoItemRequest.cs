﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Shared.Models
{
    public class ToDoItemRequest
    {
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public string PlanId { get; set; }
    }
}
