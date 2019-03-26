﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Models
{
    public class List
    {
        public int ListId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}