using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class OrderedTestAttribute: Attribute
    {
        public int Order { get; set; }

        public OrderedTestAttribute(int order)
        {
            this.Order = order;
        }
    }
}
