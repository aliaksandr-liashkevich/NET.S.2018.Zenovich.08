using System;
using System.Collections.Generic;
using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    /// <summary>
    /// Implements list hotel operations.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Hotel.DAL.API.IRepository{NET.S._2018.Zenovich._08.Hotel.DAL.Entities.HotelEntity}" />
    public class HotelRepository : IRepository<HotelEntity>
    {
        #region Private fields

        private readonly IDataAccessObject<HotelEntity> hotelDataAccessObject;
        private readonly List<HotelEntity> hotels;

        #endregion Private fields

        public HotelRepository()
        {
            hotelDataAccessObject = new HotelDataAccessObject();
            hotels = hotelDataAccessObject.GetEntities();
        }

        #region Public methods

        /// <summary>
        /// Creates the specified hotel.
        /// </summary>
        /// <param name="entity">The hotel.</param>
        public void Create(HotelEntity entity)
        {
            entity.Id = Guid.NewGuid();
            hotels.Add(entity);
        }

        /// <summary>
        /// Deletes the specified hotel.
        /// </summary>
        /// <param name="id">The hotel identifier.</param>
        public void Delete(Guid id)
        {
            var findedHotel = FindById(id);

            if (findedHotel != null)
            {
                hotels.Remove(findedHotel);
            }
        }

        /// <summary>
        /// Gets the specified hotel identifier.
        /// </summary>
        /// <param name="id">The hotel identifier.</param>
        /// <returns>the hotel.</returns>
        public HotelEntity Get(Guid id)
        {
            return FindById(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>list hotel.</returns>
        public List<HotelEntity> GetAll()
        {
            return hotels;
        }

        /// <summary>
        /// Saves this hotels.
        /// </summary>
        public void Save()
        {
            hotelDataAccessObject.PostEntities(hotels);
        }

        /// <summary>
        /// Updates the specified hotel.
        /// </summary>
        /// <param name="entity">The hotel.</param>
        public void Update(HotelEntity entity)
        {
            var updatedHotel = FindById(entity.Id);

            if (updatedHotel != null)
            {
                updatedHotel.Name = entity.Name;
                updatedHotel.Address = entity.Address;
                updatedHotel.Description = entity.Description;
                updatedHotel.StandardPricePerRoom = entity.StandardPricePerRoom;
                updatedHotel.Rating = entity.Rating;
            }
        }

        #endregion Public methods

        #region Private methods

        private HotelEntity FindById(Guid id)
        {
            return hotels.Find(hotel => hotel.Id.Equals(id));
        }

        #endregion Private methods
    }
}