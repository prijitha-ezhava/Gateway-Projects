using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email Id required")]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
