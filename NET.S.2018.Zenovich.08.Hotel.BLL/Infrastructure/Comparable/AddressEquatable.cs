using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.Comparable
{
    public class AddressEquatable : HotelDtoEquatable<string>
    {
        public AddressEquatable(string address) 
            : base(address)
        {
        }

        public override bool Equals(HotelDTO hotelDTO)
        {
            return hotelDTO.Address.Equals(_value);
        }
    }
}
