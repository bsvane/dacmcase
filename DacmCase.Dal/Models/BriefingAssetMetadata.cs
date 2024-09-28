namespace DacmCase.Dal.Models;

public class BriefingAssetMetadata
{
	public string briefId { get; set; } = string.Empty;
	public List<string>? assetIds { get; set; }
}
