using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        [Required]
        [DisplayName("License Number")]
        public string LicencePlate { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [DisplayName("Fuel Used")]
        public string FuelType { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [DisplayName("Registration Date")]
        public Nullable<System.DateTime> RegistraionDate { get; set; }
        [Required]
        [DisplayName("Chassis Number")]
        public string ChassiNo { get; set; }
        [Required]
        [DisplayName("Engine Number")]
        public string EngineNo { get; set; }
        [Required]
        [DisplayName("Customer")]
        public Nullable<int> CustomerId { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}
