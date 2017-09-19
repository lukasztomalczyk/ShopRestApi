using System;
using System.Collections.Generic;
using System.Text;
using BussinesAccessLayer.BusinessObjects;
using DataAccessLayer;
using BussinesAccessLayer.Converters;
using DataAccessLayer.Entities;
using System.Linq;

namespace BussinesAccessLayer.Services
{
    public class OrderService : IOrderService
    {
        OrderConverter converter = new OrderConverter();

        private DataAccess dataAccess;

        public OrderService(DataAccess _dataAccess)
        {
            dataAccess = _dataAccess;
        }
        public OrderBussinesObject Create(OrderBussinesObject _bussinesObject)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _orderEntity = _entryPoint.OrderRepository.Create(converter.Convert(_bussinesObject));
                _entryPoint.Complete();
                return converter.Convert(_orderEntity);
            }
         }

        public OrderBussinesObject Delete(int _idOrder)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _orderEntity = _entryPoint.OrderRepository.Delete(_idOrder);
                _entryPoint.Complete();
                return converter.Convert(_orderEntity);
            }
        }

        public OrderBussinesObject Get(int _idOrder)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _orderEntity = _entryPoint.OrderRepository.Get(_idOrder);
                _orderEntity.Customer = _entryPoint.CustomerRepository.Get(_orderEntity.CustomerId);
                return converter.Convert(_orderEntity);
            }
        }

        public List<OrderBussinesObject> GetAll()
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
               return _entryPoint.OrderRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public OrderBussinesObject Update(OrderBussinesObject _orderBussinesFromPUT)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _orderEntity = _entryPoint.OrderRepository.Get(_orderBussinesFromPUT.Id);

                if(_orderEntity == null)
                {
                    throw new InvalidOperationException("Not found Order");
                }

                _orderEntity.DeliveryDate = _orderBussinesFromPUT.DeliveryDate;
                _orderEntity.OrderDate = _orderBussinesFromPUT.OrderDate;
                _orderEntity.CustomerId = _orderBussinesFromPUT.CustomerId;
                _orderEntity.Customer = _entryPoint.CustomerRepository.Get(_orderBussinesFromPUT.CustomerId);
                _entryPoint.Complete();

                return converter.Convert(_orderEntity);
            }
        }
    }
}
