using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.Comparable
{
    /// <summary>
    /// Implements description equals.
    /// </summary>
    /// <seealso cref="string" />
    public class DescriptionEquatable : HotelDtoEquatable<string>
    {
        public DescriptionEquatable(string description)
            : base(description)
        {
        }

        public override bool Equals(HotelDto hotelDTO)
        {
            return hotelDTO.Description.Equals(this.Value);
        }
    }
}
