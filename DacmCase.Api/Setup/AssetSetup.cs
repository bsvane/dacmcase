namespace DacmCase.Api.Setup;

public static class AssetsSetup
{
	public static IServiceCollection AddAssetServices( this IServiceCollection services )
	{
		services.AddSingleton<Api.Mapping.Assets.IAssetMapper, Api.Mapping.Assets.Mapper>();

		services.AddScoped<Domain.Assets.Handlers.GetAssetUrlHandler>();

		services.AddScoped<Domain.Assets.Handlers.GetAssetMetadataHandler>();
		services.AddScoped<Domain.Assets.Handlers.AddAssetMetadataHandler>();
		services.AddScoped<Domain.Assets.Handlers.UpdateAssetMetadataHandler>();
		services.AddScoped<Domain.Assets.Handlers.DeleteAssetMetadataHandler>();

		return services;
	}
}
