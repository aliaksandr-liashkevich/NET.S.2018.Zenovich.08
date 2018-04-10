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
    /// Implements operations with array.
    /// </summary>
    /// <seealso cref="NET.S._2018.Zenovich._08.Hotel.BLL.Infrastructure.API.IArrayUtils" />
    public class ArrayUtils : IArrayUtils
    {
        #region Public methods

        /// <summary>
        /// The bubble sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="reflectorUtils">The reflector utils.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="items"/>
        /// or
        /// <paramref name="reflectorUtils"/>
        /// </exception>
        public void BubbleSort<T>(T[] items, IReflectorUtils reflectorUtils)
        {
            if (ReferenceEquals(items, null))
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (ReferenceEquals(reflectorUtils, null))
            {
                throw new ArgumentNullException(nameof(reflectorUtils));
            }

            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    IComparable indexMinusOneItem = reflectorUtils.GetPropValue(items[i - 1]) as IComparable;
                    object indexItem = reflectorUtils.GetPropValue(items[i]);

                    if (indexMinusOneItem.CompareTo(indexItem) > 0)
                    {
                        Swap(items, i - 1, i);

                        swapped = true;
                    }
                }
            }
            while (swapped != false);
        }

        /// <summary>
        /// Finds the by tag.
        /// </summary>
        /// <param name="hotelDTOs">The hotel data transfer objects.</param>
        /// <param name="equatable">The interface for equals.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="hotelDTOs"/>
        /// or
        /// <paramref name="equatable"/>
        /// </exception>
        public HotelDto FindByTag(HotelDto[] hotelDTOs, IHotelDTOEquatable equatable)
        {
            if (ReferenceEquals(hotelDTOs, null))
            {
                throw new ArgumentNullException(nameof(hotelDTOs));
            }

            if (ReferenceEquals(equatable, null))
            {
                throw new ArgumentNullException(nameof(equatable));
            }

            return hotelDTOs.FirstOrDefault((hotelDto) => equatable.Equals(hotelDto));
        }

        #endregion Public methods

        #region Private method

        private void Swap<T>(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        #endregion Private method
    }
}
