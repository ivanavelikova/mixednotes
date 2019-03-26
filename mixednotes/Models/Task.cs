using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Models
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}