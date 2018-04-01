using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<HotelEntity> hotelRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            hotelRepository = new HotelRepository();
        }

        public IRepository<HotelEntity> HotelRepository
        {
            get
            {
                return hotelRepository;
            }
        }
    }
}
