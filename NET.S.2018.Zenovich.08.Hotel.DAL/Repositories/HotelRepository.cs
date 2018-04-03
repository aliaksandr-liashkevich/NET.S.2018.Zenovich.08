using System;
using System.Collections.Generic;
using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class HotelRepository : IRepository<HotelEntity>
    {
        private readonly IDataAccessObject<HotelEntity> hotelDataAccessObject;
        private readonly List<HotelEntity> hotels;

        public HotelRepository()
        {
            hotelDataAccessObject = new HotelDataAccessObject();
            hotels = hotelDataAccessObject.GetEntities();
        }

        public void Create(HotelEntity entity)
        {
            entity.Id = Guid.NewGuid();
            hotels.Add(entity);
        }

        public void Delete(Guid id)
        {
            var findedHotel = FindById(id);

            if (findedHotel != null)
            {
                hotels.Remove(findedHotel);
            }
        }

        public HotelEntity Get(Guid id)
        {
            return FindById(id);
        }

        public IEnumerable<HotelEntity> GetAll()
        {
            return hotels;
        }

        public void Save()
        {
            hotelDataAccessObject.PostEntities(hotels);
        }

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

        private HotelEntity FindById(Guid id)
        {
            return hotels.Find(hotel => hotel.Id.Equals(id));
        }
    }
}