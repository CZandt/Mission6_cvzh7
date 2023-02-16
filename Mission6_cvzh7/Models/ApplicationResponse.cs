using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission6_cvzh7.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required(ErrorMessage ="Movie needs a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie needs a year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Movie needs a director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Movie needs a rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        // Build Foreigh Key relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
