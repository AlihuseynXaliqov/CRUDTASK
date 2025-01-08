using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Utils.Exception.Base;

namespace Business.Utils.Exception
{
    public class NegativIdException : System.Exception, IBaseException
    {
        public string ErrorMessage { get; }

        public int StatusCode { get; }
        public NegativIdException() : base()
        {
            ErrorMessage = "Id menfi ve ya sifir ola bilmez";
            StatusCode = 400;
        }

        public NegativIdException(string message) : base(message) { }

    }
}
