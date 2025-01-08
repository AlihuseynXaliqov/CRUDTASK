using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.Exception.Base
{
    public interface IBaseException
    {
        string ErrorMessage { get; }
        int StatusCode { get; }
    }
}
