using DacmCase.Dal;

namespace DacmCase.Domain.Orders.Handlers;

public class GetOrderMetadataHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public GetOrderMetadataHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public (Dal.Models.OrderListMetadata? OrderMetadata, List<Dal.Models.AssetMetadata>? AssetMetadataList) Execute( string orderNumber )
	{
		var orderMetadata = this.DalContext.OrderMetadataGet( orderNumber );
		if ( orderMetadata is null )
		{
			return (null, null);
		}

		var briefIds = orderMetadata.briefs?
			.Select( orderBrief => orderBrief.briefId );

		if ( briefIds is null || !briefIds.Any() )
		{
			return (orderMetadata, null);
		}

		var orderAssets = this.DalContext.AssetMetadataGetByBriefIds( briefIds );

		return (orderMetadata, orderAssets);
	}
}
