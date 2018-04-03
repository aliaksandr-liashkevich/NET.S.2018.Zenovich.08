using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using NET.S._2018.Zenovich._08.Hotel.BLL.API;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;
using NET.S._2018.Zenovich._08.Hotel.BLL.Validation;
using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using NET.S._2018.Zenovich._08.Hotel.DAL.Repositories;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<HotelEntity> hotelRepository;

        private IReflectorUtils reflectorUtils;
        private IArrayUtils arrayUtils;

        private bool disposed;

        static HotelService()
        {
            ConfigurateMapper();
        }

        public HotelService()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            hotelRepository = unitOfWork.HotelRepository;

            reflectorUtils = new ReflectorUtils();
            arrayUtils = new ArrayUtils();
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

        public HotelDTO Find(IHotelDTOEquatable hotelDtoEquatable)
        {
            Guard.ArgumentNotNull(nameof(hotelDtoEquatable), hotelDtoEquatable);

            IEnumerable<HotelEntity> hotelEntities = hotelRepository.GetAll();
            IEnumerable<HotelDTO> hotelDTOs = Mapper.Map<IEnumerable<HotelEntity>,IEnumerable<HotelDTO>>(hotelEntities);

            foreach (HotelDTO hotelDTO in hotelDTOs)
            {
                if (hotelDtoEquatable.Equals(hotelDTO))
                {
                    return hotelDTO;
                }
            }

            return null;
        }

        public IEnumerable<HotelDTO> SortByTag(string propertyName)
        {
            Guard.ArgumentNotNull(nameof(propertyName), propertyName);

            if (reflectorUtils.HasHotelDTOGotProperty(propertyName) == false)
            {
                throw new ArgumentException($"{nameof(HotelDTO)} has no {nameof(propertyName)}");
            }

            HotelEntity[] hotelEntities = hotelRepository.GetAll().ToArray();

            HotelDTO[] hotelDTOs = Mapper.Map<HotelEntity[], HotelDTO[]>(hotelEntities);
            arrayUtils.BubbleSort(hotelDTOs, reflectorUtils);
            
            return hotelDTOs;
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
    }
}