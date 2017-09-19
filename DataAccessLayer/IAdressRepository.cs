using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IAdressRepository
    {
        Adress Create(Adress _adress);

        Adress Delete(int _id);

        List<Adress> GetAll();

        Adress Get(int _id);
    }
}
