using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_AUTH_ASP.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string user = "DotNetIs";
        private readonly string pass = "bad";

        // key to generate jwt token
        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            
            // check username and password
            if (username == null || password == null)
            {
                return null;
            }
            if (!(user == username && pass == password))
            {
                // db logic
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            // create jwt token and return
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                // will expire after two hours
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            // get the jwt token

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
