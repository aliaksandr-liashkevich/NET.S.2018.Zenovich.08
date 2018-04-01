using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Hotel.DAL.Entities
{
    class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal StandartPricePerRoom { get; set; }
        public double Rating { get; set; }
    }
}
