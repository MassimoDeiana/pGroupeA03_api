﻿using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public class TeacherFactory : IDomainFactory<Domain.Teacher>

    { 
        public Domain.Teacher CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Teacher
            {
                IdTeacher = reader.GetInt32(reader.GetOrdinal(TeacherRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(TeacherRepository.ColName)),
                FirstName = reader.GetString(reader.GetOrdinal(TeacherRepository.ColFirstName)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(TeacherRepository.ColBirthDate)),
                Mail = reader.GetString(reader.GetOrdinal(TeacherRepository.ColMail)),
                Password = reader.GetString(reader.GetOrdinal(TeacherRepository.ColPassword))
            };    
        }
    }
}