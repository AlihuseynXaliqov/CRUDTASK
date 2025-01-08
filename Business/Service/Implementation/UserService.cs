using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Auth;
using Business.Service.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Service.Abstraction
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
       IConfiguration _config;

        public UserService(IMapper mapper, UserManager<AppUser> userManager, IConfiguration config)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            _config = config;
        }
        public async Task RegisterAsync(RegisterDto registerDto)
        {
            if (await userManager.FindByEmailAsync(registerDto.Email) != null)
            {
                throw new Exception("Hal hazirda bu email istifade edilir");
            }
            var register = mapper.Map<AppUser>(registerDto);
            var result = await userManager.CreateAsync(register,registerDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new Exception(sb.ToString());
            }

        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user= await userManager.FindByNameAsync(loginDto.Username);
            if (user == null) throw new Exception("Melumatlar sehvdir");
            var result= await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new Exception("Melumatlar sehvdir");

            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
            SigningCredentials signingCredentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: _claims,
                signingCredentials:signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(5)
                );

            var token =new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;


        }
    }
}
