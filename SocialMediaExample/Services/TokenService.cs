using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaExample.Entities;
using SocialMediaExample.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaExample.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptions _tokenOptions;

        public TokenService(IOptions<TokenOptions> tokenOptions)
        {
            // Acceder a la propiedad Value para obtener la instancia de TokenOptions
            _tokenOptions = tokenOptions.Value;

            if (string.IsNullOrWhiteSpace(_tokenOptions.SecretKey))
            {
                throw new ArgumentException("El secreto del token no puede ser nulo o vacío.", nameof(tokenOptions));
            }
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            // Verificar si el usuario es nulo
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
            }

            // Verificar si el nombre de usuario es nulo o vacío
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.", nameof(user.UserName));
            }

            // Verificar si el secreto es nulo o vacío
            if (string.IsNullOrWhiteSpace(_tokenOptions.SecretKey))
            {
                throw new ArgumentException("El secreto del token no puede ser nulo o vacío.", nameof(_tokenOptions.SecretKey));
            }

            // Definir los claims que se incluirán en el token
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.UserName),
        new Claim(ClaimTypes.Name, user.UserName)
        // Puedes agregar más claims si es necesario
    };

            // Crear la clave de seguridad usando el secreto
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crear el token JWT
            var token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_tokenOptions.ExpirationInMinutes),
                signingCredentials: creds);

            // Retornar el token como una cadena
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
