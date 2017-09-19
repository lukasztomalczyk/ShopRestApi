using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BussinesAccessLayer;
using BussinesAccessLayer.BusinessObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        BussinesLogic _bussinesLogic = new BussinesLogic();

        [HttpGet]
        public IEnumerable<OrderBussinesObject> Get()
        {
            return _bussinesLogic.OrderService.GetAll();
        }

        
        [HttpGet("{_idOrder}")]
        public OrderBussinesObject Get(int _idOrder)
        {
            return _bussinesLogic.OrderService.Get(_idOrder);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]OrderBussinesObject _orderBussinesObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderBussinesObject _orderObject = _bussinesLogic.OrderService.Create(_orderBussinesObject);
            return Ok(_orderObject);
        }

       
        [HttpPut("{_id}")]
        public IActionResult Put(int _id, [FromBody]OrderBussinesObject _orderBussinesFromPut)
        {
            if (_id != _orderBussinesFromPut.Id)
            {
                return StatusCode(405, "Patch ID does not match custorem ID in json object");
            }
            try
            {
                OrderBussinesObject _orderBussinesObject = _bussinesLogic.OrderService.Update(_orderBussinesFromPut);
                return Ok(_orderBussinesObject);
            }
            catch (InvalidOperationException exp)
            {
                return StatusCode(404, exp.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{_id}")]
        public void Delete(int _id)
        {
            _bussinesLogic.OrderService.Delete(_id);
        }
    }
}
