using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task.core.DTOs.Authentication;
using task.core.DTOs.Users;
using task.core.Interfaces.Services;

namespace task.Infrastructure.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<TokenResultDTO> GenerateTokenAsync(object userData)
        {
            UserMapDataByIdDTO? user = userData as UserMapDataByIdDTO
                ?? throw new ArgumentException("El objeto userData no es de tipo UserMapDataByIdDTO", nameof(userData));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new(ClaimTypes.Name, user.NameUser),
                new(ClaimTypes.Email, user.EmailUser),
                new("IsActive", user.IsActiveUser.ToString())
            };

            if (!string.IsNullOrEmpty(user.SpecialitiesUser))
            {
                claims.Add(new Claim("Specialities", user.SpecialitiesUser));

                if (user.SpecialitiesUser == "Estudiante")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Student"));
                }
                else if (user.SpecialitiesUser == "Administrador")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                }
            }

            if (!string.IsNullOrEmpty(user.PhoneUser))
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneUser));
            }

            var expirationHours = _configuration["JWT:ExpirationHours"];
            if (!double.TryParse(expirationHours, out double expHours))
            {
                expHours = 2.0;
            }

            var expirationTime = DateTime.UtcNow.AddHours(expHours);
            var secretKey = _configuration["JWT:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expirationTime,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var result = new TokenResultDTO
            {
                Token = tokenString,
                Expiration = expirationTime
            };

            return await Task.FromResult(result);
        }
    }
}