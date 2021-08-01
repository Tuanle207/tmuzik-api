using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tmuzik.Infrastructure.DependencyInjections;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Linq;

namespace Tmuzik.Infrastructure.Services.Authorization
{
    public class AuthHelper : ISingletonDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthHelper> _logger;

        public AuthHelper(IConfiguration configuration, ILogger<AuthHelper> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Hash password with HMACSHA512 algolrithm using salt
        /// </summary>
        /// <param name="password">Plain user password</param>
        /// <returns>The tupple of HASHED PASSWORD and SALT in order.</returns>
        public (string, string) HashPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var passwordSalt = Convert.ToBase64String(hmac.Key);
                var passwordHash = Convert.ToBase64String(
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
                return (passwordHash, passwordSalt);
            }
        }

        public bool VerifyPassword(string candidatePassword, string storedPasswordHashed, string salt)
        {
            var key = Convert.FromBase64String(salt);
            var hashedPassword = Convert.FromBase64String(storedPasswordHashed);
            using(var hmac = new System.Security.Cryptography.HMACSHA512(key))
            { 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(candidatePassword));
                for (int i = 0; i < computedHash.Length; i++)
                { // Loop through the byte array and compare each one
                    if (computedHash[i] != hashedPassword[i]) 
                        return false; // if mismatch
                }    
            }
            return true; //if no mismatches.
        }


        public string GenerateToken(string id)
        {
            var secretKey = _configuration["Jwt:SecretKey"];
            var expiresIn = 0;
            if (!Int32.TryParse(_configuration["Jwt:ExpireTime"], out expiresIn))
            {
                expiresIn = 5;
            }
            var issuer = _configuration["Jwt:Issuer"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescription = new SecurityTokenDescriptor

            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
                Expires = DateTime.Now.AddMinutes(expiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512
                ),
                Issuer = issuer,
                IssuedAt = DateTime.Now
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        public Guid? ValidateToken(string token)
        {
            try 
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = _configuration["Jwt:SecretKey"];
                var key = Encoding.ASCII.GetBytes(secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                _logger.LogInformation($"claims -- {System.Text.Json.JsonSerializer.Serialize(jwtToken.Claims)}");
                var id = jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value;
                _logger.LogInformation($"id -- {id}");
                return new Guid(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}