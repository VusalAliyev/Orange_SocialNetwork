using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
