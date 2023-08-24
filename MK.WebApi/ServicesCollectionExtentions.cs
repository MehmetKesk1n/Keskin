using System.Text.Json.Serialization;

namespace MK.WebApi
{
    public static class ServicesCollectionExtentions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
