using System;
using System.Collections.Generic;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.API
{
    public interface IHotelService : IDisposable
    {
        void Add(HotelDto hotelDto);

        void Delete(Guid id);

        HotelDto GetHotel(Guid id);

        IEnumerable<HotelDto> GetHotels();

        void Update(HotelDto hotelDto);

        HotelDto Find(IHotelDTOEquatable hotelDtoForEquals);

        IEnumerable<HotelDto> SortByTag(string propertyName);
    }
}