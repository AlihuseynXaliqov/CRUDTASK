using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Utils.Exception.Base;

namespace Business.Utils.Exception
{
    public class NotFoundException<T> : System.Exception,IBaseException where T : class
    {
        public string ErrorMessage { get; }
        public int StatusCode { get; }
        public NotFoundException() : base() {
            ErrorMessage = $"{typeof(T).Name} movcud deyil";
            StatusCode = 400;
        }

        public NotFoundException(string message) : base(message) { }

    }
}
