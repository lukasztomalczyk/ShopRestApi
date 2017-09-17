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
            _dataAccess = dataAccess;
        }
        public OrderBussinesObject Create(OrderBussinesObject _bussinesObject)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _unitOfWork = _entryPoint.OrderRepository.Create(converter.Convert(_bussinesObject));
                _entryPoint.Complete();
                return converter.Convert(_unitOfWork);
            }
         }

        public OrderBussinesObject Delete(int _idOrder)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _unitOfWork = _entryPoint.OrderRepository.Delete(_idOrder);
                _entryPoint.Complete();
                return converter.Convert(_unitOfWork);
            }
        }

        public OrderBussinesObject Get(int _idOrder)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _unitOfWork = _entryPoint.OrderRepository.Get(_idOrder);
                return converter.Convert(_unitOfWork);
            }
        }

        public List<OrderBussinesObject> GetAll()
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
               return _entryPoint.OrderRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public OrderBussinesObject Update(OrderBussinesObject _orderBussines)
        {
            using (IUnitOfWork _entryPoint = dataAccess.UnitOfWork)
            {
                Order _orderEntity = _entryPoint.OrderRepository.Get(_orderBussines.Id);

                if(_orderEntity == null)
                {
                    throw new InvalidOperationException("Not found Order");
                }

                _orderEntity.DeliveryDate = _orderBussines.DeliveryDate;
                _orderEntity.OrderDate = _orderBussines.OrderDate;
                _entryPoint.Complete();

                return converter.Convert(_orderEntity);
            }
        }
    }
}
