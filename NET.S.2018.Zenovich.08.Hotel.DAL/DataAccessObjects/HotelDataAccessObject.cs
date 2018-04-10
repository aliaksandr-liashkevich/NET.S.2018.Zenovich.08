using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.FileSystem.API;

namespace NET.S._2018.Zenovich._08.Hotel.FileSystem.DataAccessObjects
{
    public class HotelDataAccessObject : IDataAccessObject<HotelEntity>
    {
        #region Public fields

        public const string DefaulFilePath = "Hotels.bin";

        public static readonly string FilePath;

        #endregion Public fields

        static HotelDataAccessObject()
        {
            FilePath = ConfigurationManager.AppSettings.Get("FilePath");

            if (FilePath == null)
            {
                FilePath = DefaulFilePath;
            }

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        #region Public methods

        /// <summary>
        /// Gets the hotels.
        /// </summary>
        /// <returns>list hotel.</returns>
        public List<HotelEntity> GetEntities()
        {
            var hotels = new List<HotelEntity>();

            using (var reader = new BinaryReader(File.Open(FilePath, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() != -1)
                {
                    var hotel = new HotelEntity();

                    hotel.Id = Guid.Parse(reader.ReadString());
                    hotel.Name = reader.ReadString();
                    hotel.Address = reader.ReadString();
                    hotel.Description = reader.ReadString();
                    hotel.StandardPricePerRoom = reader.ReadDecimal();
                    hotel.Rating = reader.ReadDouble();

                    hotels.Add(hotel);
                }
            }

            return hotels;
        }

        /// <summary>
        /// Posts the hotels.
        /// </summary>
        /// <param name="hotels">The hotels.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="hotels"/>
        /// </exception>
        public void PostEntities(List<HotelEntity> hotels)
        {
            if (ReferenceEquals(hotels, null))
            {
                throw new ArgumentNullException(nameof(hotels));
            }

            using (var writer = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (var hotel in hotels)
                {
                    writer.Write(hotel.Id.ToString());
                    writer.Write(hotel.Name);
                    writer.Write(hotel.Address);
                    writer.Write(hotel.Description);
                    writer.Write(hotel.StandardPricePerRoom);
                    writer.Write(hotel.Rating);
                }
            }
        }

        #endregion Public methods
    }
}