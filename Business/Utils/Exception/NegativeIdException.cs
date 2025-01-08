using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.Exception
{
    public class NegativeIdException : System.Exception,NegativeIdException
    {
        public NegativeIdException() : base("Id menfi ve ya sifir ola bilmez") { }

        public NegativeIdException(string message) : base(message) { }
    }
}
