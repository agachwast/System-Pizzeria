using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjketC
{
    internal class NieZnalezionoPracownikaException : Exception
    {
        public NieZnalezionoPracownikaException() : base() { }

        public NieZnalezionoPracownikaException(string message) : base(message) { }
    }
}
