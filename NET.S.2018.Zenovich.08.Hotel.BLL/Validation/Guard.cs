using System;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Validation
{
    public class Guard
    {
        public static void ArgumentNotNull(string argumentName, object value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}