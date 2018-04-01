using NET.S._2018.Zenovich._08.Hotel.BLL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Validation
{
    public class ValidationDetails : IValidationDetails
    {
        public ValidationDetails(string property, string message, bool isValid)
        {
            Property = property;
            Message = message;
            IsValid = isValid;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
        public bool IsValid { get; private set; }
    }
}
