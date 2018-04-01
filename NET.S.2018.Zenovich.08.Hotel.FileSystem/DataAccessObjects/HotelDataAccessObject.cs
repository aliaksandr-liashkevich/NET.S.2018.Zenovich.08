using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;

namespace NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects
{
    public class HotelDataAccessObject : IDataAccessObject<HotelEntity>
    {
        public List<HotelEntity> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
