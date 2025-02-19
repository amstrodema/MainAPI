﻿using MainAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MainAPI.Services
{
    public class JWTService
    {
        public string GenerateSecurityToken(UserSession userSession)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim("userId", userSession.UserID.ToString()),
                new Claim("emailAddress", userSession.EmailAddress.ToString(), ClaimValueTypes.Email),
                new Claim("fullname", userSession.Fullname.ToString()),
            });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("iTellerSecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(subject),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
