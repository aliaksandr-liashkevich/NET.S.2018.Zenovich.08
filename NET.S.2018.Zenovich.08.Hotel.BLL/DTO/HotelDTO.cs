using System;
using System.Collections.Generic;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.DTO
{
    public class HotelDTO : IComparable, IComparable<HotelDTO>, IEquatable<HotelDTO>
    {
        public HotelDTO()
        {
            Name = string.Empty;
            Address = string.Empty;
            Description = string.Empty;
        }

        public string Address { get; set; }

        public string Description { get; set; }

        public Guid Id { get; set; }

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

            return CompareTo((HotelDTO)objHotelDTO);
        }

        public int CompareTo(HotelDTO comparedHotelDTO)
        {
            if (ReferenceEquals(comparedHotelDTO, null))
            {
                return -1;
            }

            return StandardPricePerRoom.CompareTo(comparedHotelDTO.Id);
        }

        public override bool Equals(object objHotelDTO)
        {
            var hotelDTO = objHotelDTO as HotelDTO;
            return hotelDTO != null &&
                   Id.Equals(hotelDTO.Id) &&
                   Name == hotelDTO.Name &&
                   Address == hotelDTO.Address &&
                   Description == hotelDTO.Description &&
                   StandardPricePerRoom == hotelDTO.StandardPricePerRoom &&
                   Rating == hotelDTO.Rating;
        }

        public bool Equals(HotelDTO objHotelDTO)
        {
            return this.Equals(objHotelDTO);
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

        public override string ToString()
        {
            return $"Guid: {Id}\nName: {Name}\nAddress: {Address}\nDescription: {Description}\n" +
                   $"Standart price per room: {StandardPricePerRoom}\nRating: {Rating}";
        }
    }
}