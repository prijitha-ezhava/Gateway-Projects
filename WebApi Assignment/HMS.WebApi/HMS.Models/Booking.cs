using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Booking
    {
        public int bID { get; set; }
        public System.DateTime bDate { get; set; }
        public string bStatus { get; set; }
        public Nullable<int> rID { get; set; }

    }
}
