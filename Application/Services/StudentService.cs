using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Helpers;
using Application.UseCases.Student.Dtos;
using Domain;
using Infrastructure.SqlServer.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly AppSettings _appSettings;

        public StudentService(IEntityRepository<Student> studentRepository, IOptions<AppSettings> appSettings)
        {
            _studentRepository = studentRepository;
            _appSettings = appSettings.Value;
        }

        public OutputDtoTokenStudent Authenticate(InputDtoGenerateTokenStudent model)
        {
            var student = _studentRepository.GetAll()
                .SingleOrDefault(student => student.Mail == model.Mail && student.Password == model.Password);

            // return null if student not found
            if (student == null) return null;
            
            // authentication successful so generate jwt token
            var token = GenerateJwtToken(student);

            return new OutputDtoTokenStudent(student, token);
        }
        
        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
        
        private string GenerateJwtToken(Student student)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("idstudent", student.IdStudent.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}