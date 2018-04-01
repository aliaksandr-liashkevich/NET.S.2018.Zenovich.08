using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.API
{
    public interface IHotelService
    {
        IEnumerable<HotelDTO> GetHotels();
        HotelDTO GetHotel(Guid id);
        void Create(HotelDTO hotelDTO);
        void Update(HotelDTO hotelDTO);
        void Delete(HotelDTO hotelDTO);
    }
}
