using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjketC
{
    internal class KlientIstniejeException : Exception
    {
        public KlientIstniejeException() : base() { }

        public KlientIstniejeException(string message) : base(message) { }
    }
}
