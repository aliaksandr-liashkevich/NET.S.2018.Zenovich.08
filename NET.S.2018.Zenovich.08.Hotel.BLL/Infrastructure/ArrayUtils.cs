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
    class ArrayUtils : IArrayUtils
    {
        private void Swap<T>(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        public void BubbleSort<T>(T[] items, IReflectorUtils reflectorUtils)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    IComparable iMinusOneItem = reflectorUtils.GetPropValue(items[i - 1]) as IComparable;
                    object iItem = reflectorUtils.GetPropValue(items[i]);

                    if (iMinusOneItem.CompareTo(iItem) > 0)
                    {
                        Swap(items, i - 1, i);

                        swapped = true;
                    }
                }
            }

            while (swapped != false);
        }

        public HotelDTO FindByTag(HotelDTO[] hotelDTOs, IHotelDTOEquatable equatable)
        {
            throw new NotImplementedException();
        }
    }
}
