namespace DacmCase.Api.Contracts.Assets;

public class AssetMetadata
{
	public string AssetId { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string? FileFormat { get; set; }
	public int? FileSize { get; set; }
	public string CreatedBy { get; set; } = string.Empty;
	public Version? VersionNumber { get; set; }
	public DateTime Timestamp { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string Comments { get; set; } = string.Empty;
	public string Path { get; set; } = string.Empty;
	public string PathPreview { get; set; } = string.Empty;
	public AssetStatus? Status { get; set; }
}
