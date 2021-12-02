using System.Collections.Generic;
using Application.Helpers;
using Application.Services;
using Application.UseCases.Meeting;
using Application.UseCases.Note;
using Application.UseCases.ParticipateMeeting;
using Application.UseCases.SchoolClass;
using Application.UseCases.Student;
using Application.UseCases.Teacher;
using Domain;
using Infrastructure.SqlServer.Repositories.Meeting;
using Infrastructure.SqlServer.Repositories.Note;
using Infrastructure.SqlServer.Repositories.ParticipateMeeting;
using Infrastructure.SqlServer.Repositories.SchoolClass;
using Infrastructure.SqlServer.Repositories.Student;
using Infrastructure.SqlServer.Repositories.Teacher;
using Infrastructure.SqlServer.System;
using Infrastructure.SqlServer.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace pGroupeA03_api
{
    public class Startup
    {
        public static readonly string MyOrigins = "MyOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            // Add repos
            services.AddSingleton<SchoolClassFactory>();
            services.AddSingleton<IEntityRepository<SchoolClass>, SchoolClassRepository>();
            
            services.AddSingleton<StudentFactory>();
            services.AddSingleton<IEntityRepository<Student>, StudentRepository>();
            services.AddSingleton<IStudentRepository, StudentRepository>();

            services.AddSingleton<TeacherFactory>();
            services.AddSingleton<IEntityRepository<Teacher>, TeacherRepository>();
            
            services.AddSingleton<MeetingFactory>();
            services.AddSingleton<IEntityRepository<Meeting>, MeetingRepository>();

            services.AddSingleton<NoteFactory>();
            services.AddSingleton<IEntityRepository<Note>, NoteRepository>();

            services.AddSingleton<ParticipateMeetingFactory>();
            services.AddSingleton<IEntityRepository<ParticipateMeeting>, ParticipateMeetingRepository>();
            services.AddSingleton<IParticipateMeetingRepository, ParticipateMeetingRepository>();

            services.AddSingleton<IDatabaseManager, DatabaseManager>();

            //USECASE
                //TEACHER
                services.AddSingleton<UseCaseCreateTeacher>();
                services.AddSingleton<UseCaseGetTeacher>();
                services.AddSingleton<UseCaseGenerateTeacher>();
                services.AddSingleton<UseCaseDeleteTeacher>();
                services.AddSingleton<TeacherService>();
                services.AddSingleton<AppSettings>();
                
                //STUDENT
                services.AddSingleton<UseCaseGetStudent>();
                services.AddSingleton<UseCaseCreateStudent>();
                services.AddSingleton<UseCaseGenerateStudent>();
                services.AddSingleton<UseCaseUpdateStudent>();
                services.AddSingleton<UseCaseDeleteStudent>();

                //SCHOOLCLASS
                services.AddSingleton<UseCaseCreateSchoolClass>();
                services.AddSingleton<UseCaseGetSchoolClass>();
                services.AddSingleton<UseCaseGenerateSchoolClass>();
                services.AddSingleton<UseCaseDeleteSchoolClass>();
                
                //MEETING
                services.AddSingleton<UseCaseCreateMeeting>();
                services.AddSingleton<UseCaseGetMeeting>();
                services.AddSingleton<UseCaseGenerateMeeting>();
                services.AddSingleton<UseCaseDeleteMeeting>();
                
                //NOTE
                services.AddSingleton<UseCaseCreateNote>();
                services.AddSingleton<UseCaseGetNote>();
                services.AddSingleton<UseCaseGenerateNote>();
                services.AddSingleton<UseCaseDeleteNote>();
                
                //PARTICIPATEMEETING
                services.AddSingleton<UseCaseCreateParticipateMeeting>();
                services.AddSingleton<UseCaseGetParticipateMeeting>();
                services.AddSingleton<UseCaseGenerateParticipateMeeting>();
                services.AddSingleton<UseCaseDeleteParticipateMeeting>();

                services.AddControllers();
            
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            // configure DI for application services
            services.AddScoped<ITeacherService, TeacherService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }
            else
            {
                app.UseHttpsRedirection();
            }

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            
            app.UseCors(MyOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}