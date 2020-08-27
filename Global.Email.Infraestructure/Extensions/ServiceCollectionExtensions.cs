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
using System;
using System.Collections.Generic;

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