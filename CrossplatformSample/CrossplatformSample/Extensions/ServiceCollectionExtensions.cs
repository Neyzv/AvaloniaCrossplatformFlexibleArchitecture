using CrossplatformSample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CrossplatformSample.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedServices(this IServiceCollection serviceCollection) =>
        serviceCollection.AddSingleton<ISampleService, SampleService>();
}