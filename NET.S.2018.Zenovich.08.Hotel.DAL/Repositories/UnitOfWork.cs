using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IHotelRepository hotelRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            hotelRepository = new HotelRepository();
        }

        public IHotelRepository HotelRepository
        {
            get
            {
                return hotelRepository;
            }
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void CleanUp(bool clean)
        {
            if (!this.disposed)
            {
                if (clean)
                {
                    hotelRepository.Dispose();
                }
            }

            this.disposed = true;
        }

        ~UnitOfWork()
        {
            CleanUp(false);
        }
    }
}
