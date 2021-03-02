using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassengersCRUD.Models
{
    public class PassengersViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mobile is required!")]
        [DisplayName("Mobile")]
        public string Mobile { get; set; }
    }
}