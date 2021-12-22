using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Helpers;
using Application.UseCases.Teacher.Dtos;
using Domain;
using Infrastructure.SqlServer.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IEntityRepository<Teacher> _teacherRepository;
        private readonly AppSettings _appSettings;

        public TeacherService(IEntityRepository<Teacher> teacherRepository, IOptions<AppSettings> appSettings)
        {
            _teacherRepository = teacherRepository;
            _appSettings = appSettings.Value;
        }

        /**
         * <summary>Vérifie si le mail et le mot de passe encodé existe dans la base de données.
         * Si oui, la méthode renvoie un objet contenant l'id de l'utilisateur et un token</summary>
         */
        public OutputDtoTokenTeacher Authenticate(InputDtoGenerateTokenTeacher model)
        {
            var teacher = _teacherRepository.GetAll()
                .SingleOrDefault(teacher => teacher.Mail == model.Mail && teacher.Password == model.Password);

             // return null if user not found
            if (teacher == null) return null;
            
            // authentication successful so generate jwt token
            var token = GenerateJwtToken(teacher);

            return new OutputDtoTokenTeacher(teacher, token);
        }
        
        public Teacher GetById(int id)
        {
            return _teacherRepository.GetById(id);
        }
        
        /**
         * <summary>Génère un token en fonction du secret stocké et de l'utilisateur dans appsettings.json</summary>
         * <<param name="teacher">L'utilisateur</param>
         */
        private string GenerateJwtToken(Teacher teacher)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("idteacher", teacher.IdTeacher.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}