using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    /// <summary>
    /// Encapsulate repositories.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Hotel.DAL.API.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            HotelRepository = new HotelRepository();
        }

        /// <summary>
        /// Gets the hotel repository.
        /// </summary>
        /// <value>
        /// The hotel repository.
        /// </value>
        public IRepository<HotelEntity> HotelRepository { get; }
    }
}