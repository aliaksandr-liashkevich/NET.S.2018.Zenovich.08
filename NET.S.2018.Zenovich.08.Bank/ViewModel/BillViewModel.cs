using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Zenovich._08.Bank.ViewModel
{
    /// <summary>
    /// View model account operation
    /// </summary>
    public class BillViewModel
    {
        public Guid ClientId { get; set; }

        public decimal Currency { get; set; }
    }
}
