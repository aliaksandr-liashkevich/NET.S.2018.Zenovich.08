using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using System.IO;

namespace NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects
{
    public class HotelDataAccessObject : IDataAccessObject<HotelEntity>
    {
        public const string DefaulFilePath = "Hotels.bin";
        public static readonly string FilePath;

        static HotelDataAccessObject()
        {
            FilePath = ConfigurationManager.AppSettings.Get("FilePath");

            if (FilePath == null)
            {
                FilePath = DefaulFilePath;
            }
        }

        public List<HotelEntity> GetEntities()
        {
            List<HotelEntity> hotels = new List<HotelEntity>();

            using (BinaryReader reader = new BinaryReader(File.Open(FilePath, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() != -1)
                {
                    HotelEntity hotel = new HotelEntity();

                    hotel.Id = Guid.Parse(reader.ReadString());
                    hotel.Name = reader.ReadString();
                    hotel.Address = reader.ReadString();
                    hotel.Description = reader.ReadString();
                    hotel.StandartPricePerRoom = reader.ReadDecimal();
                    hotel.Rating = reader.ReadDouble();

                    hotels.Add(hotel);
                }
            }

            return hotels;
        }

        public void PostEntities(List<HotelEntity> hotels)
        {
            if (Object.ReferenceEquals(hotels, null))
            {
                throw new ArgumentNullException(nameof(hotels));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (HotelEntity hotel in hotels) 
                {
                    writer.Write(hotel.Id.ToString());
                    writer.Write(hotel.Name);
                    writer.Write(hotel.Address);
                    writer.Write(hotel.Description);
                    writer.Write(hotel.StandartPricePerRoom);
                    writer.Write(hotel.Rating);
                }
            }
        }
    }
}
