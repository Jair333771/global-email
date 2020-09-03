using AutoMapper;
using FluentValidation.AspNetCore;
using Global.Email.Application.Interface;
using Global.Email.Application.ResponseModel;
using Global.Email.Domain.Entities;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using Global.Email.Domain.Services;
using Global.Email.Infraestructure.Context;
using Global.Email.Infraestructure.Options;
using Global.Email.Infraestructure.Repositories;
using Global.Email.Infraestructure.Services;
using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Global.Email.Infraestructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services) {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Email Transactions",
                    Version = "v1",
                    Description = "Email Transactions Microservice"
                });

                doc.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var assembly = GetAssemblyByName("Global.Email.Api");
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlRoute = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlRoute);
            });
            return services;
        }

        public static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   FirstOrDefault(assembly => assembly.GetName().Name == name);
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IGlobalResponse, GlobalResponse>();
            services.AddTransient<IErrorResponses, ErrorListResponse>();

            services.AddTransient<ISendHeaderDetailService<SendHeaderDetail>, SendHeaderDetailService>();
            services.AddTransient<ISendHeaderService<SendHeader>, SendHeaderService>();
            services.AddTransient<INetCoreUserService<NetCoreUser>, NetCoreUserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddSingleton<IMandrillApi>(provider =>
            {
                var apiKey = configuration.GetValue<string>("Mandrill:ApiKey");
                return new MandrillApi(apiKey);
            });

            services.AddTransient<EmailAddress, EmailAddress>();
            services.AddTransient<EmailMessage, EmailMessage>();
            services.AddTransient<List<EmailAddress>, List<EmailAddress>>();
            services.AddTransient(provider =>
            {
                return new SendMessageRequest(new EmailMessage());
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });

            services.AddMvc();

            return services;
        }

        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = configuration.GetValue<string>("Authentication:Issuer"),
                     ValidAudience = configuration.GetValue<string>("Authentication:Audience"),
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Authentication:SecretKey")))
                 };

            });
            return services;
        }
    }
}