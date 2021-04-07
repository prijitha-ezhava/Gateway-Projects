using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities.ViewModel
{
    public class VehicleViewModel
    {
        public int ID { get; set; }
        [Display(Name = "License Number")]
        public string licensePlate { get; set; }
        [Display(Name = "Manufacturer")]
        public string Make { get; set; }
        public string Model { get; set; }
        [Display(Name = " Registration Date")]
        public System.DateTime? registrationDate { get; set; }
        [Display(Name = " Chasis Number")]
        public string chasisNo { get; set; }
        [Display(Name = "Customer ID")]
        public int custID { get; set; }
        
    }
}
