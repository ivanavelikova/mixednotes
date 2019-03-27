using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Note
    {
        public int NoteId { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    }
}
