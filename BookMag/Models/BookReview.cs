using System;
using System.ComponentModel.DataAnnotations;

namespace BookMag.Models
{
    public class BookReview
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Комментарий")]
        public String Review { get; set; }

        public int BookId { get; set; }

        public int Likes { get; set; }

        public bool IsOffensive { get; set; }

        [Display(Name = "Жалоба")]
        public string ReportReason { get; set; }
    }
}