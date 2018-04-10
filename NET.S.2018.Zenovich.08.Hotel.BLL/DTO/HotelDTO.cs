using System;
using System.Collections.Generic;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.DTO
{
    /// <summary>
    /// Data transfer object
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IComparable{NET.S._2018.Zenovich._08.Hotel.BLL.DTO.HotelDTO}" />
    /// <seealso cref="System.IEquatable{NET.S._2018.Zenovich._08.Hotel.BLL.DTO.HotelDTO}" />
    public class HotelDto : IComparable, IComparable<HotelDto>, IEquatable<HotelDto>, IFormattable
    {
        public HotelDto()
        {
            Name = string.Empty;
            Address = string.Empty;
            Description = string.Empty;
        }

        public Guid Id { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public decimal StandardPricePerRoom { get; set; }

        public int CompareTo(object objHotelDTO)
        {
            if (ReferenceEquals(objHotelDTO, null))
            {
                return -1;
            }

            if (GetType() != objHotelDTO.GetType())
            {
                throw new InvalidCastException(nameof(objHotelDTO));
            }

            return CompareTo((HotelDto)objHotelDTO);
        }

        public int CompareTo(HotelDto comparedHotelDTO)
        {
            if (ReferenceEquals(comparedHotelDTO, null))
            {
                return -1;
            }

            return StandardPricePerRoom.CompareTo(comparedHotelDTO.Id);
        }

        public override bool Equals(object objHotelDto)
        {
            var hotelDto = objHotelDto as HotelDto;
            return hotelDto != null &&
                   Id.Equals(hotelDto.Id) &&
                   Name == hotelDto.Name &&
                   Address == hotelDto.Address &&
                   Description == hotelDto.Description &&
                   StandardPricePerRoom == hotelDto.StandardPricePerRoom &&
                   Rating == hotelDto.Rating;
        }

        public bool Equals(HotelDto objHotelDto)
        {
            return this.Equals(objHotelDto);
        }

        public override int GetHashCode()
        {
            var hashCode = -1455158527;
            hashCode *= -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode *= -1521134295 + StandardPricePerRoom.GetHashCode();
            hashCode *= -1521134295 + Rating.GetHashCode();
            return hashCode;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return $"Type: {typeof(HotelDto)}\nName: {Name}\nAddress: {Address}\nDescription: {Description}\n" +
                   $"Standart price per room: {StandardPricePerRoom}\nRating: {Rating}";
        }
    }
}