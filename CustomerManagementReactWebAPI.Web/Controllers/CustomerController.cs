using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementReactWebAPI.Interfaces.Services;
using CustomerManagementReactWebAPI.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementReactWebAPI.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            return Json(customerService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer model)
        {
            return Json(customerService.Add(model));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer model)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            return Json(customerService.Update(id, model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.Delete(id);
        }
    }
}
