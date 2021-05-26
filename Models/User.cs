using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAppWithTests.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="UserName length must be between 3 and 50 characters long", MinimumLength = 3)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [StringLength(50, ErrorMessage = "Password length must be between 3 and 50 characters long", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
