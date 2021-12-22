using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Helpers;
using Application.UseCases.Admin.Dtos;
using Domain;
using Infrastructure.SqlServer.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IEntityRepository<Admin> _adminRepository;
        private readonly AppSettings _appSettings;

        public AdminService(IEntityRepository<Admin> adminRepository, IOptions<AppSettings> appSettings)
        {
            _adminRepository = adminRepository;
            _appSettings = appSettings.Value;
        }
        
        /**
         * <summary>Vérifie si le mail et le mot de passe encodé existe dans la base de données.
         * Si oui, la méthode renvoie un objet contenant l'id de l'utilisateur et un token</summary>
         */
        public OutputDtoTokenAdmin Authenticate(InputDtoGenerateTokenAdmin model)
        {
            var admin = _adminRepository.GetAll()
                .SingleOrDefault(student => student.Mail == model.Mail && student.Password == model.Password);

            // return null if admin not found
            if (admin == null) return null;
            
            // authentication successful so generate jwt token
            var token = GenerateJwtToken(admin);

            return new OutputDtoTokenAdmin(admin, token);
        }

        public Admin GetById(int id)
        {
            return _adminRepository.GetById(id);
        }
        
        /**
         * <summary>Génère un token en fonction du secret stocké et de l'utilisateur dans appsettings.json</summary>
         * <<param name="admin">L'utilisateur</param>
         */
        private string GenerateJwtToken(Admin admin)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("idadmin", admin.IdAdmin.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}