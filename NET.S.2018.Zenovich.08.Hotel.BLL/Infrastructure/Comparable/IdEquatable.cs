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
    /// Implements id equals.
    /// </summary>
    /// <seealso cref="Guid" />
    public class IdEquatable : HotelDtoEquatable<Guid>
    {
        public IdEquatable(Guid id)
            : base(id)
        {
        }

        public override bool Equals(HotelDto hotelDTO)
        {
            return hotelDTO.Id.Equals(this.Value);
        }
    }
}
