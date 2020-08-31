using AutoMapper;
using FluentValidation.AspNetCore;
using Global.Email.Domain.Interfaces.Repositories;
using Global.Email.Domain.Interfaces.Services;
using Global.Email.Domain.Interfaces.UnitOfWork;
using Global.Email.Domain.Services;
using Global.Email.Infraestructure.Context;
using Global.Email.Infraestructure.Repositories;
using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services) {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Email Transactions",
                    Version = "v1",
                    Description = "Email Transactions Microservice"
                });

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
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
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

            return services;
        }
    }
}