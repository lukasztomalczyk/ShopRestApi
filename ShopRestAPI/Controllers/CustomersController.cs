using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BussinesAccessLayer;
using BussinesAccessLayer.BusinessObjects;

namespace ShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        BussinesLogic bussinesLogic = new BussinesLogic();

        [HttpGet]
        public IEnumerable<CustomerBussinesObject> Get()
        {
            return bussinesLogic.CustomerService.GetAll();
        }

        
        [HttpGet("{_id}")]
        public CustomerBussinesObject Get(int _id)
        {
            return bussinesLogic.CustomerService.Get(_id);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] CustomerBussinesObject customerObjectFromPost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerBussinesObject _customerObject = bussinesLogic.CustomerService.Create(customerObjectFromPost);
            return Ok(_customerObject);
        }

        
        [HttpPut("{_id}")]
        public IActionResult Put(int _id, [FromBody] CustomerBussinesObject _customerObjectFromPut)
        {
            if (_id != _customerObjectFromPut.Id)
            {
                return StatusCode(405, "Patch ID does not match custorem ID in json object");
            }
            try
            {
                CustomerBussinesObject _customerObject = bussinesLogic.CustomerService.Update(_customerObjectFromPut);
                return Ok(_customerObject);
            }
            catch (InvalidOperationException exp)
            {
                return StatusCode(404, exp.Message);
            }
                        
          
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bussinesLogic.CustomerService.Delete(id);
        }
    }
}
