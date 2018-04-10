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
    /// <summary>
    /// Implements hotel operations.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Hotel.BLL.API.IHotelService" />
    public class HotelService : IHotelService
    {
        #region Private fields

        private readonly IRepository<HotelEntity> hotelRepository;

        private IReflectorUtils reflectorUtils;

        private IArrayUtils arrayUtils;

        private bool disposed;

        #endregion Private fields

        #region Public ctor

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

        #endregion Public ctor

        ~HotelService()
        {
            CleanUp(false);
        }

        #region Public methods

        /// <summary>
        /// Adds the specified hotel data transfer object.
        /// </summary>
        /// <param name="hotelDto">The hotel data transfer object.</param>
        public void Add(HotelDto hotelDto)
        {
            Guard.ArgumentNotNull(nameof(hotelDto), hotelDto);

            var hotel = Mapper.Map<HotelDto, HotelEntity>(hotelDto);
            hotelRepository.Create(hotel);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            Guard.ArgumentNotNull(nameof(id), id);

            hotelRepository.Delete(id);
        }

        /// <summary>
        /// Gets the hotel.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the hotel data transfer object.</returns>
        public HotelDto GetHotel(Guid id)
        {
            Guard.ArgumentNotNull(nameof(id), id);

            var hotel = hotelRepository.Get(id);
            if (hotel == null)
            {
                return Mapper.Map<HotelEntity, HotelDto>(hotel);
            }

            return null;
        }

        /// <summary>
        /// Gets the hotels.
        /// </summary>
        /// <returns>hotels.</returns>
        public IEnumerable<HotelDto> GetHotels()
        {
            var hotelEntities = hotelRepository.GetAll();

            return Mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelDto>>(hotelEntities);
        }

        /// <summary>
        /// Updates the specified hotel data transfer object.
        /// </summary>
        /// <param name="hotelDto">The hotel data transfer object.</param>
        public void Update(HotelDto hotelDto)
        {
            Guard.ArgumentNotNull(nameof(hotelDto), hotelDto);
            Guard.ArgumentNotNull(nameof(hotelDto.Id), hotelDto.Id);

            var hotel = Mapper.Map<HotelDto, HotelEntity>(hotelDto);
            hotelRepository.Update(hotel);
        }

        /// <summary>
        /// Finds the specified hotel data transfer object.
        /// </summary>
        /// <param name="hotelDtoForEquals">The hotel data transfer object for equals.</param>
        /// <returns>Found hotel data transfer object.</returns>
        public HotelDto Find(IHotelDTOEquatable hotelDtoForEquals)
        {
            Guard.ArgumentNotNull(nameof(hotelDtoForEquals), hotelDtoForEquals);

            IEnumerable<HotelDto> hotelDTOs = Mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelDto>>(hotelRepository.GetAll());

            foreach (HotelDto hotelDTO in hotelDTOs)
            {
                if (hotelDtoForEquals.Equals(hotelDTO))
                {
                    return hotelDTO;
                }
            }

            return null;
        }

        /// <summary>
        /// Sorts the by tag.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">HotelDTO</exception>
        public IEnumerable<HotelDto> SortByTag(string propertyName)
        {
            Guard.ArgumentNotNull(nameof(propertyName), propertyName);

            if (reflectorUtils.HasHotelDtoGotProperty(propertyName) == false)
            {
                throw new ArgumentException($"{nameof(HotelDto)} has no {nameof(propertyName)}");
            }

            HotelEntity[] hotelEntities = hotelRepository.GetAll().ToArray();

            HotelDto[] hotelDTOs = Mapper.Map<HotelEntity[], HotelDto[]>(hotelEntities);
            arrayUtils.BubbleSort(hotelDTOs, reflectorUtils);
            
            return hotelDTOs;
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public methods

        #region Protected methods

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

        #endregion Protected methods

        #region Private methods

        private static void ConfigurateMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<HotelDto, HotelEntity>();
                config.CreateMap<HotelEntity, HotelDto>();
            });
        }

        #endregion Private methods
    }
}