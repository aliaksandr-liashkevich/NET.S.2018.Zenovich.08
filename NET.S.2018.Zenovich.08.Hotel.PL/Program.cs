using System;
using System.Reflection;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.Comparable;
using NET.S._2018.Zenovich._08.Hotel.BLL.Services;

namespace NET.S._2018.Zenovich._08.Hotel.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var service = new HotelService())
            {
                /*
                 var hotelDto = new HotelDTO();
                 hotelDto.Name = "Alexandrya";
                 hotelDto.Address = "10 Alexandrya, 20 flat , France.";
                 hotelDto.Description = "At Hotel Alexandrya you will be welcomed amongst olive trees, citron trees and magnolias, in gardens that hide exotic plants and in a wonderful outdoor pool with deck chairs; protected against the sun’s rays by big umbrellas you can enjoy a drink amongst the wisteria bushes.";
                 hotelDto.StandardPricePerRoom = 50;
                 hotelDto.Rating = 2.1;
 
                 service.Add(hotelDto);*/
                IHotelDTOEquatable equatable = new NameEquatable("Nosya");

                var qFind = service.Find(equatable);

                Console.WriteLine("Finding:\n" + qFind + "\n");

                var q = service.SortByTag("Rating");

                foreach (var hotel in q)
                {
                    Console.WriteLine(hotel);
                    Console.WriteLine(new string('-', 20));
                }

                Console.ReadKey();
            }
        }
    }
}
