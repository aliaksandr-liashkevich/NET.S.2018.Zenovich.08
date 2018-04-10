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
    /// <summary>
    /// Implements reflection with property.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API.IReflectorUtils" />
    public class ReflectorUtils : IReflectorUtils
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

        /// <summary>
        /// Determines whether [has hotel data transfer object got property] [the specified property name].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        ///   <c>true</c> if [has hotel data transfer object got property] [the specified property name]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="propertyName"/> is null or empty
        /// </exception>
        public bool HasHotelDtoGotProperty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException($"{propertyName} is null or empty");
            }

            Type type = typeof(HotelDto);
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

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>property value.</returns>
        public object GetPropValue(object obj)
        {
            return PropertyInfo.GetValue(obj);
        }
    }
}
