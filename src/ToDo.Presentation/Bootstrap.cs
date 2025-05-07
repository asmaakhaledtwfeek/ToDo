using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace ToDo.Presentation
{
    public static class Bootstrap
    {
        public static void AddPresentationStrapping(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(AssemblyReference.Assembly)
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}
