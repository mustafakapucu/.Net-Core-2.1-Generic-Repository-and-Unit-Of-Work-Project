using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Repository.Context;
using Repository.IUnitOfWork;
using Repository.Models;
using Repository.Repositories;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const string baseMail = "@test.com";
        private readonly IUserServices userService;
        public ValuesController(IUserServices userService)
        {
            this.userService = userService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Repository.Models.User user = new Repository.Models.User();
            user.CreatedDate = DateTime.Now;
            user.Email = Guid.NewGuid() + baseMail;
            user.FirstName = "test";
            user.LastName = "user";
            user.Password = "***";
            userService.add(user);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int? id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
