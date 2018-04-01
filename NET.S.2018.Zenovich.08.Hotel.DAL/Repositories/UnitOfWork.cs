using NET.S._2018.Zenovich._08.Hotel.DAL.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void CleanUp(bool clean)
        {
            if (!this.disposed)
            {
                if (clean)
                {

                }
            }

            this.disposed = true;
        }

        ~UnitOfWork()
        {
            CleanUp(false);
        }
    }
}
