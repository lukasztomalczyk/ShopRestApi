using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BussinesAccessLayer;
using BussinesAccessLayer.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private BussinesLogic _bussinesLogic;

        public AddressController(BussinesLogic bussinesLogic)
        {
            _bussinesLogic = bussinesLogic;
        }
       
        [HttpGet]
        public IEnumerable<AddressBussinesObject> Get()
        {
            return _bussinesLogic.AddressService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{_id}")]
        public AddressBussinesObject Get(int _id)
        {
            return _bussinesLogic.AddressService.Get(_id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AddressBussinesObject _addressBussinesFromPOST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AddressBussinesObject _addressBussinesObject = _bussinesLogic.AddressService.Create(_addressBussinesFromPOST);
            return Ok(_addressBussinesObject);
        }

        /*
        [HttpPut("{_id}")]
        public IActionResult Put(int _id, [FromBody]AddressBussinesObject _addressBussinesFromPUT)
        {
            if (_id != _addressBussinesFromPUT.Id)
            {
                return StatusCode(404, "ID from URL not match to ID object send");
            }

            AddressBussinesObject _addressBussinesObject = _bussinesLogic.AddressService.
        }  */

        // DELETE api/values/5
        [HttpDelete("{_id}")]
        public AddressBussinesObject Delete(int _id)
        {
            return _bussinesLogic.AddressService.Delete(_id);
        }
    }
}
