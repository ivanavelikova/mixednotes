using System.ComponentModel.DataAnnotations;

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
