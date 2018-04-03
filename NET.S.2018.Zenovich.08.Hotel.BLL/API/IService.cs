using System;
using System.Collections.Generic;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.API
{
    public interface IHotelService : IDisposable
    {
        void Add(HotelDTO hotelDTO);

        void Delete(Guid id);

        HotelDTO GetHotel(Guid id);

        IEnumerable<HotelDTO> GetHotels();

        void Update(HotelDTO hotelDTO);

        HotelDTO Find(String propertyValue);

        IEnumerable<HotelDTO> SortByTag(String propertyName);
    }
}