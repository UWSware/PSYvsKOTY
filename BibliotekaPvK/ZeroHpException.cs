using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaPvK
{
    public class ZeroHpException : Exception
    {
        public ZeroHpException() { }

        public ZeroHpException(string message) : base(message) { }

        public ZeroHpException(string message, Exception inner) : base(message, inner) { }
    }
}
