using DacmCase.Api.Mapping.Orders;
using DacmCase.Domain.Orders.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DacmCase.Api.Controllers;

[ApiController]
[Route( "Api/[controller]" )]
public class OrderController(
	GetOrderMetadataHandler getOrderMetadataHandler,
	IOrderMapper orderMapper,
	ILogger<OrderController> logger ) : ControllerBase
{
	private GetOrderMetadataHandler GetOrderMetadataHandler { get; } = getOrderMetadataHandler;

	private IOrderMapper OrderMapper { get; } = orderMapper;
	private ILogger<OrderController> Logger { get; } = logger;

	[HttpGet( "Metadata/{orderNumber}" )]
	public ActionResult<Api.Contracts.Orders.OrderMetadata> GetOrderMetadata( string orderNumber )
	{
		var orderHandlerResult = this.GetOrderMetadataHandler.Execute( orderNumber );
		if ( orderHandlerResult.OrderMetadata is null )
		{
			return this.NotFound();
		}

		var mappedOrderMetadata = this.OrderMapper.Map( orderHandlerResult.OrderMetadata, orderHandlerResult.AssetMetadataList );

		return this.Ok( mappedOrderMetadata );
	}
}
