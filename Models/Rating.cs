using System;
using System.ComponentModel.DataAnnotations;

namespace projectoFinalV2.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FilmId { get; set; }

        [Required, StringLength(100)]
        public string UserName { get; set; }

        [Required, StringLength(1000)]
        public string Comment { get; set; }  

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
