using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Validation
{
    public class Guard
    {
        public static void ArgumentNotNull(string argumentName, Object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
