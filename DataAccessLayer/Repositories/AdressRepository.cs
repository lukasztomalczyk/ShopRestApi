using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class AdressRepository : IAdressRepository
    {
        public ContextDB contextDB { get; internal set; }

        public AdressRepository(ContextDB _contextDB)
        {
            this.contextDB = _contextDB;  
        }

        public Adress Create(Adress _adress)
        {
            contextDB.Adressess.Add(_adress);
            return _adress;
        }

        public Adress Delete(int _id)
        {
            Adress _entityAdress = Get(_id);
            contextDB.Adressess.Remove(_entityAdress);
            return _entityAdress;
        }

        public List<Adress> GetAll()
        {
            throw new NotImplementedException();
        }

        public Adress Get(int _id)
        {
            return contextDB.Adressess.FirstOrDefault(a => a.Id == _id);
        }
    }
}
