using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAppWithTests.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        
        [Required, StringLength(50)]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Screen Time")]
        public string MovieTime { get; set; }

        [Required]
        [StringLength(3)]
        public string Rating { get; set; }

    }
}
