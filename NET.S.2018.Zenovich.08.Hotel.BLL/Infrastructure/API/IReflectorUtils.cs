using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API
{
    public interface IReflectorUtils
    {
        bool HasHotelDtoGotProperty(string propertyName);

        object GetPropValue(object obj);
    }
}
