using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAppWithTests.Models
{
    public class LoginCredential
    {
        [Required,StringLength(50,MinimumLength =3)]
        public string UserName { get; set; }
        [Required, StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
