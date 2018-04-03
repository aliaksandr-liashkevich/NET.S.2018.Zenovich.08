using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.Comparable
{
    public class DescriptionEquatable : HotelDtoEquatable<String>
    {
        public DescriptionEquatable(string description)
            : base(description)
        {
        }

        public override bool Equals(HotelDTO hotelDTO)
        {
            return hotelDTO.Description.Equals(_value);
        }
    }
}
