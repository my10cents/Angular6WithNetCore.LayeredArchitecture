using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Api.AppHelpers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policyName)
        {
            services.AddCors(options => options.AddPolicy(policyName, builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowCredentials();

                builder.WithExposedHeaders(new[] {
                    "X-Custom-Header",
                    "Location",
                    "Content-Disposition",
                    "Content-Length",
                });
            }));
            return services;
        }
    }
}
