namespace DacmCase.Api.Mapping.Assets;

public class Mapper : IAssetMapper
{
	private const string ToBeDefinedPlaceholder = "ToBeDefined";

	public Api.Contracts.Assets.AssetMetadata Map( Dal.Models.AssetMetadata assetMetadata )
	{
		int? fileSize = null;
		if ( int.TryParse( assetMetadata.fileSize, out var tmpFileSize ) )
		{
			fileSize = tmpFileSize;
		}

		Api.Contracts.Assets.AssetStatus? status = null;
		if ( Enum.TryParse<Api.Contracts.Assets.AssetStatus>( assetMetadata.Status, out var tmpStatus ) )
		{
			status = tmpStatus;
		}

		Version.TryParse( assetMetadata.VersionNumber, out var versionNumber );

		return new Api.Contracts.Assets.AssetMetadata
		{
			AssetId = assetMetadata.assetId,
			Name = assetMetadata.name,
			Description = assetMetadata.description,
			FileFormat = assetMetadata.fileFormat != ToBeDefinedPlaceholder ? assetMetadata.fileFormat : null,
			FileSize = fileSize,
			CreatedBy = assetMetadata.createdBy,
			VersionNumber = versionNumber,
			Timestamp = assetMetadata.Timestamp,
			UserName = assetMetadata.UserName,
			Comments = assetMetadata.Comments,
			Path = assetMetadata.path,
			PathPreview = assetMetadata.Preview,
			Status = status != Api.Contracts.Assets.AssetStatus.Unknown ? status : null,
		};
	}

	public List<Api.Contracts.Assets.AssetMetadata> Map( IEnumerable<Dal.Models.AssetMetadata> assetMetadataList )
	{
		return assetMetadataList
			.Select( this.Map )
			.ToList();
	}

	public Dal.Models.AssetMetadata Map( Api.Contracts.Assets.AssetMetadata assetMetadata )
	{
		return new Dal.Models.AssetMetadata
		{
			assetId = assetMetadata.AssetId,
			name = assetMetadata.Name,
			description = assetMetadata.Description,
			fileFormat = !string.IsNullOrEmpty( assetMetadata.FileFormat ) ? assetMetadata.FileFormat : ToBeDefinedPlaceholder,
			fileSize = assetMetadata.FileSize.HasValue ? assetMetadata.FileSize.Value.ToString() : ToBeDefinedPlaceholder,
			createdBy = assetMetadata.CreatedBy,
			VersionNumber = assetMetadata.VersionNumber is not null ? $"{assetMetadata.VersionNumber.Major}.{assetMetadata.VersionNumber.Minor}" : ToBeDefinedPlaceholder,
			Timestamp = assetMetadata.Timestamp,
			UserName = assetMetadata.UserName,
			Comments = assetMetadata.Comments,
			path = assetMetadata.Path,
			Preview = assetMetadata.PathPreview,
			Status = assetMetadata.Status.HasValue && assetMetadata.Status != Api.Contracts.Assets.AssetStatus.Unknown ? assetMetadata.Status.Value.ToString() : ToBeDefinedPlaceholder,
		};
	}
}
