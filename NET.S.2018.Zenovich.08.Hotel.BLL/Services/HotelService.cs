using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using NET.S._2018.Zenovich._08.Hotel.BLL.API;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Validation;
using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.DAL.Repositories;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<HotelEntity> hotelRepository;

        private bool disposed;

        static HotelService()
        {
            ConfigurateMapper();
        }

        public HotelService()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            hotelRepository = unitOfWork.HotelRepository;
        }

        ~HotelService()
        {
            CleanUp(false);
        }

        public void Add(HotelDTO hotelDTO)
        {
            Guard.ArgumentNotNull(nameof(hotelDTO), hotelDTO);

            var hotel = Mapper.Map<HotelDTO, HotelEntity>(hotelDTO);
            hotelRepository.Create(hotel);
        }

        public void Delete(Guid id)
        {
            Guard.ArgumentNotNull(nameof(id), id);

            hotelRepository.Delete(id);
        }

        public HotelDTO GetHotel(Guid id)
        {
            Guard.ArgumentNotNull(nameof(id), id);

            var hotel = hotelRepository.Get(id);
            if (hotel == null)
            {
                return Mapper.Map<HotelEntity, HotelDTO>(hotel);
            }

            return null;
        }

        public IEnumerable<HotelDTO> GetHotels()
        {
            var hotelEntities = hotelRepository.GetAll();

            return Mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelDTO>>(hotelEntities);
        }

        public void Update(HotelDTO hotelDTO)
        {
            Guard.ArgumentNotNull(nameof(hotelDTO), hotelDTO);
            Guard.ArgumentNotNull(nameof(hotelDTO.Id), hotelDTO.Id);

            var hotel = Mapper.Map<HotelDTO, HotelEntity>(hotelDTO);
            hotelRepository.Update(hotel);
        }

        public HotelDTO Find(string propertyValue)
        {
            return null;
        }

        public IEnumerable<HotelDTO> SortByTag(string propertyName)
        {
            if (ReferenceEquals(propertyName, null))
            {
                throw new ArgumentNullException(propertyName);
            }

            PropertyInfo property = GetPropertyHotelDto(propertyName);

            if (property == null)
            {
                throw new ArgumentException("", propertyName);
            }

            return null;
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        protected void CleanUp(bool clean)
        {
            if (!disposed)
            {
                if (clean)
                {
                    hotelRepository.Save();
                }
            }
                
            disposed = true;
        }

        private static void ConfigurateMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<HotelDTO, HotelEntity>();
                config.CreateMap<HotelEntity, HotelDTO>();
            });
        }

        private PropertyInfo GetPropertyHotelDto(string propertyName)
        {
            Type type = typeof(HotelDTO);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo result = null;

            foreach (PropertyInfo property in properties)
            {

                if (property.CanRead 
                    && property.GetGetMethod(true).IsPublic 
                    && property.PropertyType.IsSubclassOf(typeof(IComparable)) 
                    && property.Name.Equals(propertyName))
                {
                    return result;
                }
            }

            return result;
        }
    }
}