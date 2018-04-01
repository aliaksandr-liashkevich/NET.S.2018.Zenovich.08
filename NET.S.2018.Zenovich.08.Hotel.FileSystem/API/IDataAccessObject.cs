using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.FileSystem.API
{
    public interface IDataAccessObject<T>
    {
        List<T> GetEntities();
    }
}
