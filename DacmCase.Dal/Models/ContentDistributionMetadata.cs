namespace DacmCase.Dal.Models;

public class ContentDistributionMetadata
{
	public class ContentDistributionMetadataAsset
	{
		public string assetId { get; set; } = string.Empty;
		public string name { get; set; } = string.Empty;
		public string fileURL { get; set; } = string.Empty;
	}

	public string distributionDate { get; set; } = string.Empty;
	public List<string>? distributionChannels { get; set; }
	public List<string>? distributionMethods { get; set; }
	public List<ContentDistributionMetadataAsset>? assets { get; set; }
}
