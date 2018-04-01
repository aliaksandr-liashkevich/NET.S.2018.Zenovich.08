using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private List<HotelEntity> hotels;
        private 


        public HotelRepository()
        {
            hotels = new List<HotelEntity>();
        }


        public void Dispose()
        {
            
        }
    }
}
