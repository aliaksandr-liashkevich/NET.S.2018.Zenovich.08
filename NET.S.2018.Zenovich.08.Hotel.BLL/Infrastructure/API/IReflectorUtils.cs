using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API
{
    interface IReflectorUtils
    {
        bool HasHotelDTOGotProperty(string propertyName);

        object GetPropValue(Object obj);
    }
}
