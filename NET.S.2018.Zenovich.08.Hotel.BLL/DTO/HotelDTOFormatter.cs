using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.DTO
{
    /// <summary>
    /// Hotel data transfer object formatter
    /// </summary>
    /// <seealso cref="System.ICustomFormatter" />
    /// <seealso cref="System.IFormatProvider" />
    public class HotelDTOFormatter : ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is HotelDto && format == "short")
            {
                var hotelDto = (HotelDto)arg;

                var builder = new StringBuilder();

                builder.Append(arg.GetType() + "\n");
                builder.AppendFormat("Name:\t{0}\n", hotelDto.Name);
                builder.AppendFormat("Address:\t{0}\n", hotelDto.Address);
                builder.AppendFormat("Rating:\t{0}\n", hotelDto.Rating);

                return builder.ToString();
            }
            else
            {
                var formattable = arg as IFormattable;

                return formattable != null
                    ? formattable.ToString(format, formatProvider)
                    : arg.ToString();
            }
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter)
                ? this
                : CultureInfo.CurrentCulture.GetFormat(formatType);
        }
    }
}
