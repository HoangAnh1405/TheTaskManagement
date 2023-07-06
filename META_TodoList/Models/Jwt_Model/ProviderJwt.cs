using META_TodoList.Models.User_Model;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace META_TodoList.Models.Jwt_Model
{
    internal sealed class ProviderJwt : IProviderJwt
    {
        private readonly JwtOptions _options;

        public ProviderJwt(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string Generate(UserSignIn user)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Name, user._id),
                    };
            var signingCredentials = new SigningCredentials
                (
                new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: signingCredentials,
                claims: claims);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);



            return tokenString;
        }
    }
}
