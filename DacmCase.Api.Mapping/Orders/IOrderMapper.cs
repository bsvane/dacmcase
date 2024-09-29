namespace DacmCase.Api.Mapping.Orders;

public interface IOrderMapper
{
	Api.Contracts.Orders.OrderMetadata Map( Dal.Models.OrderListMetadata orderMetadata, IEnumerable<Dal.Models.AssetMetadata>? assetMetadatas );
}