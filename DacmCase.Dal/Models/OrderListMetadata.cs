namespace DacmCase.Dal.Models;

public class OrderListMetadata
{
	public class OrderListMetadataBrief
	{
		public string briefId { get; set; } = string.Empty;
		public int quantity { get; set; }
	}

	public string orderNumber { get; set; } = string.Empty;
	public string requesterName { get; set; } = string.Empty;
	public string orderDate { get; set; } = string.Empty;
	public string campaignName { get; set; } = string.Empty;
	public int totalBriefs { get; set; }
	public List<OrderListMetadataBrief>? briefs { get; set; }
}
