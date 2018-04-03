using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.API
{
    public interface IUnitOfWork
    {
        IRepository<HotelEntity> HotelRepository { get; }
    }
}