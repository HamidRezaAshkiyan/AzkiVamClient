using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzkiVamClient.Extensions;

public static partial class IServiceCollectionExtensions
{
    public static IServiceCollection AddAzkiVamClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IAzkiVamClient, AzkiVamClient>(client =>
        {
            AzkiVamGatewayOptions options = new();
            configuration.GetSection(AzkiVamGatewayOptions.ConfigurationSection).Bind(options);

            client.BaseAddress = options.BaseUrl;
            client.DefaultRequestHeaders.Add(
                nameof(options.MerchantId),
                options.MerchantId);
        });

        return services;
    }
}
