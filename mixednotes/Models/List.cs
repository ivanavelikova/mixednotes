using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
