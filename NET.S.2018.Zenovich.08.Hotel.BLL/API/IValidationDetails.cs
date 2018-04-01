using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.API
{
    public interface IValidationDetails
    {
        string Property { get; }
        string Message { get; }
        bool IsValid { get; }
    }
}
