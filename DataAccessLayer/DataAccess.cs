using DataAccessLayer.Repositories;
using DataAccessLayer.UOW;
using System;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
