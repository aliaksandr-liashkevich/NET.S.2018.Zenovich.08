using AutoMapper;
using NET.S._2018.Zenovich._08.Hotel.BLL.API;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Validation;
using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using NET.S._2018.Zenovich._08.Hotel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Services
{
    public class HotelService : IHotelService
    {
        private IRepository<HotelEntity> hotelRepository;
        
        public HotelService(IUnitOfWork unitOfWork)
        {
            hotelRepository = unitOfWork.HotelRepository;
        }

        public HotelDTO GetHotel(Guid id)
        {
            Guard.ArgumentNotNull(nameof(id), id);

            HotelEntity hotel =  hotelRepository.Get(id);
            if (hotel == null)
            {
                Mapper.Initialize(config => config.CreateMap<HotelEntity, HotelDTO>());
                return Mapper.Map<HotelEntity, HotelDTO>(hotel);
            }

            return null;
        }

        public IEnumerable<HotelDTO> GetHotels()
        {
            IEnumerable<HotelEntity> hotelEntities = hotelRepository.GetAll();

            Mapper.Initialize(config => config.CreateMap<HotelEntity, HotelDTO>());
            return Mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelDTO>> (hotelEntities);
        }

        public void Create(HotelDTO hotelDTO)
        {
            Guard.ArgumentNotNull(nameof(hotelDTO), hotelDTO);

            HotelEntity hotel = MapHotelDTOToHotelEntity(hotelDTO);
            hotelRepository.Create(hotel);
        }

        public void Delete(HotelDTO hotelDTO)
        {
            Guard.ArgumentNotNull(nameof(hotelDTO), hotelDTO);
            Guard.ArgumentNotNull(nameof(hotelDTO.Id), hotelDTO.Id);

            HotelEntity hotel = MapHotelDTOToHotelEntity(hotelDTO);
            hotelRepository.Delete(hotel);
        }

        public void Update(HotelDTO hotelDTO)
        {
            Guard.ArgumentNotNull(nameof(hotelDTO), hotelDTO);
            Guard.ArgumentNotNull(nameof(hotelDTO.Id), hotelDTO.Id);

            HotelEntity hotel = MapHotelDTOToHotelEntity(hotelDTO);
            hotelRepository.Update(hotel);
        }

        private HotelEntity MapHotelDTOToHotelEntity(HotelDTO hotelDTO)
        {
            Mapper.Initialize(config => config.CreateMap<HotelDTO, HotelEntity>());
            return Mapper.Map<HotelDTO, HotelEntity>(hotelDTO);
        }
    }
}
