namespace DacmCase.Dal.Models;

public class AssetMetadata
{
	public string assetId { get; set; } = string.Empty;
	public string name { get; set; } = string.Empty;
	public string description { get; set; } = string.Empty;
	public string fileFormat { get; set; } = string.Empty;
	public string fileSize { get; set; } = string.Empty;
	public string path { get; set; } = string.Empty;
	public string createdBy { get; set; } = string.Empty;
	public string VersionNumber { get; set; } = string.Empty;
	public DateTime Timestamp { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string Comments { get; set; } = string.Empty;
	public string Preview { get; set; } = string.Empty;
	public string Status { get; set; } = string.Empty;
}
