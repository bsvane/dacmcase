
namespace DacmCase.Api.Contracts.Orders;

public class OrderMetadata
{
	public string OrderNumber { get; set; } = string.Empty;
	public string RequesterName { get; set; } = string.Empty;
	public string OrderDate { get; set; } = string.Empty;
	public string CampaignName { get; set; } = string.Empty;

	public List<Assets.AssetMetadata>? AssetMetadataList { get; set; }
}
