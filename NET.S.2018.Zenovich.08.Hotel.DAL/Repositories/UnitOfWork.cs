using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            HotelRepository = new HotelRepository();
        }

        public IRepository<HotelEntity> HotelRepository { get; }
    }
}