using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservices.Entities;

namespace Product.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet("getProduct")]
        public ActionResult<IEnumerable<string>> Get()
        {
            Products products = GetDummyData();
            return Ok(products);
        }


        private Products GetDummyData()
        {
            Products products = new Products
            {
                Id = 1,
                Name = "HardDisk",
                Price = "$98",
                Category = "Technology"
            };
            return products;
        }
    }
}