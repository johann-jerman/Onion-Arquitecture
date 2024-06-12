using Application.DTO;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        public string Login(UserDTO user) 
        {
            return new JwtSecurityTokenHandler().WriteToken(GenJwt(user));
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new ();
            TokenValidationParameters validationParameters = GetTokenValidatorParameters();

            return tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        }

        private JwtSecurityToken GenJwt(UserDTO user)
        {
            return new JwtSecurityToken(
                    //issuer: "yourdomain.com", //->  emmiter of token
                    //audience: "yourdomain.com", //-> receiver of token
                    claims: GetClaims(user),
                    expires: DateTime.Now.AddMinutes(60 * 12), // -> 12 hour
                    signingCredentials: GetCredentials()
                );
        }

        private SigningCredentials GetCredentials()
        {
            // this must be a real securitykey
            return new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.HmacSha256);
        }

        private SymmetricSecurityKey GetSecurityKey() 
        {
            return new(Encoding.UTF8.GetBytes("SecurityKet62Bits"));
        }

        private Claim[] GetClaims(UserDTO user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

        private TokenValidationParameters GetTokenValidatorParameters() 
        {
            return new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(),
            };
        }
       

        public void Logout() 
        {

        }

    }
}
