using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Helpers.JwtMiddleware
{
    public class JwtMiddlewareStudent
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddlewareStudent(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        
        /**
          * <summary>Méthode permettant de vérifier si un token doit être précisé dans l'en-tête de la requête
          * Si oui, la méthode AttachUserToContext est appelée</summary>
          * <param name="context">Le contexte de la requête http</param>
          * <param name="service">Le service à utiliser lors de l'appel de AttachUserToContext</param>
          */
        public async Task Invoke(HttpContext context, IStudentService service)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, service, token);

            await _next(context);
        }

        /**
           * <summary>Méthode permettant de valider le token, d'extraire l'id de l'utilisateur et d'attacher l'utilisateur au contexte</summary>
           * <param name="context">Le contexte de la requête http</param>
           * <param name="service">Le service utilisé pour récupérer l'utilisateur</param>
           * <param name="token">Le token</param>
           */
        private void AttachUserToContext(HttpContext context, IStudentService service, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var studentId = int.Parse(jwtToken.Claims.First(x => x.Type == "idstudent").Value);

                // attach user to context on successful jwt validation
                context.Items["Student"] = service.GetById(studentId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}