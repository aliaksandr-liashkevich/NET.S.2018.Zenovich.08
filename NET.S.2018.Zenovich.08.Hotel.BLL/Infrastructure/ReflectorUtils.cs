using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Zenovich._08.Hotel.BLL.DTO;
using NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure
{
    class ReflectorUtils : IReflectorUtils
    {
        private PropertyInfo _propertyInfo;

        private PropertyInfo PropertyInfo
        {
            get
            {
                return _propertyInfo;

            }
            set
            {
                _propertyInfo = value ?? throw new ArgumentNullException(nameof(PropertyInfo));
            }
        }

        public bool HasHotelDTOGotProperty(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException($"{propertyName} is null or empty");
            }

            Type type = typeof(HotelDTO);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {

                if (property.CanRead
                    && property.GetGetMethod(true).IsPublic
                    && typeof(IComparable).IsAssignableFrom(property.PropertyType)
                    && property.Name.Equals(propertyName))
                {
                    PropertyInfo = property;
                    return true;
                }
            }

            return false;
        }

        public object GetPropValue(Object obj)
        {
            return PropertyInfo.GetValue(obj);
        }
    }
}
