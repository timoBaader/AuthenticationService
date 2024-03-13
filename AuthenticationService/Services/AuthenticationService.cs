using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Services
{
    public class AuthenticationService
    {
        private const int TokenExpiryInMinutes = 60; // Token expiry time in minutes
        private readonly IConfiguration _config;

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string username)
        {
            var secretKey = _config["JWT_SECRET_KEY"];
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpiryInMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        public bool ValidateToken(string token)
        {
            var secretKey = _config["JWT_SECRET_KEY"];
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey!);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            try
            {
                tokenHandler.ValidateTokenAsync(token, validationParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
