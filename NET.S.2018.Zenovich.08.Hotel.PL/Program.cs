using System;
using System.Reflection;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
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
                 hotelDto.Name = "Nosya";
                 hotelDto.Address = "30 Nosya Morte, 111 flat , France.";
                 hotelDto.Description = "At Hotel Nosya you will be welcomed amongst olive trees, citron trees and magnolias, in gardens that hide exotic plants and in a wonderful outdoor pool with deck chairs; protected against the sun’s rays by big umbrellas you can enjoy a drink amongst the wisteria bushes.";
                 hotelDto.StandardPricePerRoom = 150;
                 hotelDto.Rating = 1.1;
 
                 service.Add(hotelDto);
                */

                PropertyInfo[] properties = typeof(HotelDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);


                foreach (var hotel in service.GetHotels())
                {
                    Console.WriteLine(hotel);
                    Console.WriteLine(new string('-', 20));
                }
            }
        }
    }
}
