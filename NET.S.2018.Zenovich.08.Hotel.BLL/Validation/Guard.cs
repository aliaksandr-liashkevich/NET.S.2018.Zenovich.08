using System;

namespace NET.S._2018.Zenovich._08.Hotel.BLL.Validation
{
    /// <summary>
    /// Implements checks.
    /// </summary>
    public class Guard
    {
        /// <summary>
        /// Arguments the not null.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/>
        /// </exception>
        public static void ArgumentNotNull(string argumentName, object value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}