using System.ComponentModel.DataAnnotations;

namespace Database_First.Models
{
    public class StudDF
    {
        [Key]
        public int Stud_id { get; set; }

        [Required]
        public required string Name { get; set; }

       
        public string? Address { get; set; }
    }
}
