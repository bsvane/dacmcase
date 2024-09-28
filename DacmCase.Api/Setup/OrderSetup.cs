namespace DacmCase.Api.Setup;

public static class OrderSetup
{
	public static IServiceCollection AddOrderServices( this IServiceCollection services )
	{
		services.AddSingleton<Domain.Orders.IOrderMapper, Domain.Orders.Mapper>();

		services.AddScoped<Domain.Orders.Handlers.GetOrderMetadataHandler>();

		return services;
	}
}
