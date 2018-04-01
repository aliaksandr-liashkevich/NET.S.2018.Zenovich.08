using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class HotelRepository : IRepository<HotelEntity>
    {
        private List<HotelEntity> hotels;
        private IDataAccessObject<HotelEntity> hotelDataAccessObject;

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

        public void Delete(HotelEntity entity)
        {
            hotels.Remove(entity);
        }

        public HotelEntity Get(Guid id)
        {
            return hotels.Find((hotel) => hotel.Id.Equals(id));
        }

        public IEnumerable<HotelEntity> GetAll()
        {
            return hotels;
        }

        public void Update(HotelEntity entity)
        {
            HotelEntity updatedHotel = hotels.Find((hotel) => hotel.Id.Equals(entity));
            if (updatedHotel != null)
            {
                updatedHotel.Name = entity.Name;
                updatedHotel.Address = entity.Address;
                updatedHotel.Description = entity.Description;
                updatedHotel.StandartPricePerRoom = entity.StandartPricePerRoom;
                updatedHotel.Rating = entity.Rating;
            }
        }

        public void Save()
        {
            hotelDataAccessObject.PostEntities(hotels);
        }
    }
}
