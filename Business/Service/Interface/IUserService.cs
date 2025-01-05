using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Auth;

namespace Business.Service.Interface
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto registerDto);
    
        Task<string> LoginAsync(LoginDto loginDto);
    }

}
