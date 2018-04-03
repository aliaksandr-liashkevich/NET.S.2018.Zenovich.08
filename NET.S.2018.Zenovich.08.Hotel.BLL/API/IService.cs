using System;
using System.Collections.Generic;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.API
{
    public interface IHotelService : IDisposable
    {
        void Add(HotelDTO hotelDTO);

        void Delete(Guid id);

        HotelDTO GetHotel(Guid id);

        IEnumerable<HotelDTO> GetHotels();

        void Update(HotelDTO hotelDTO);

        HotelDTO Find(IHotelDTOEquatable hotelDtoEquatable);

        IEnumerable<HotelDTO> SortByTag(String propertyName);
    }
}