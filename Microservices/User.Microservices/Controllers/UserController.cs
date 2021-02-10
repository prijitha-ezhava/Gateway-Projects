using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Microservices.Entities;

namespace User.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        [HttpGet("getUser")]
        public ActionResult<IEnumerable<Users>> Get()
        {
            Users users = GetDummyData();
            return Ok(users);
        }

        private Users GetDummyData()
        {
            Users user = new Users
            {
                Id = 1,
                Name = "Prijitha Ezhava",
                Address = "Ahmedabad",
                Email = "prijitha@gmail.com",
                Age = 22
            };
            return user;
        }
    }
}