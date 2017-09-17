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
    public class OrderController : Controller
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
