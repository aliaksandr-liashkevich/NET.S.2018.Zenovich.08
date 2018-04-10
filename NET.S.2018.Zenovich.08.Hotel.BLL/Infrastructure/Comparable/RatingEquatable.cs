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
    /// Implements rating equals.
    /// </summary>
    /// <seealso cref="double" />
    public class RatingEquatable : HotelDtoEquatable<double>
    {
        public RatingEquatable(double rating)
            : base(rating)
        {
        }

        public override bool Equals(HotelDto hotelDTO)
        {
            return hotelDTO.Rating.Equals(this.Value);
        }
    }
}
