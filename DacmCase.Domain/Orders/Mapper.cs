using DacmCase.Domain.Assets;

namespace DacmCase.Domain.Orders;

public class Mapper : IOrderMapper
{
	private IAssetMapper AssetMapper { get; }

	public Mapper( IAssetMapper assetMapper )
	{
		this.AssetMapper = assetMapper;
	}

	public Api.Contracts.Orders.OrderMetadata Map( Dal.Models.OrderListMetadata orderMetadata, IEnumerable<Dal.Models.AssetMetadata>? assetMetadatas )
	{
		return new Api.Contracts.Orders.OrderMetadata
		{
			OrderNumber = orderMetadata.orderNumber,
			CampaignName = orderMetadata.campaignName,
			OrderDate = orderMetadata.orderDate,
			RequesterName = orderMetadata.requesterName,
			AssetMetadataList = assetMetadatas is not null ? this.AssetMapper.Map( assetMetadatas ) : null,
		};
	}
}
