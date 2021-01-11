using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Hotel
    {
        public int hID { get; set; }
        public string hName { get; set; }
        public string hAddress { get; set; }
        public string hCity { get; set; }
        public int hPincode { get; set; }
        public string hContactNumber { get; set; }
        public string hContactPerson { get; set; }
        public string hWebsite { get; set; }
        public string hFacebook { get; set; }
        public string hTwitter { get; set; }
        public bool hIsActive { get; set; }
        public DateTime hCreatedDate { get; set; }
        public string hCreatedBy { get; set; }
        public DateTime hUpdatedDate { get; set; }
        public string hUpdatedBy { get; set; }

    }
}
