namespace DacmCase.Domain.Assets;

public interface IAssetMapper
{
	Api.Contracts.Assets.AssetMetadata Map( Dal.Models.AssetMetadata assetMetadata );
	Dal.Models.AssetMetadata Map( Api.Contracts.Assets.AssetMetadata assetMetadata );
	List<Api.Contracts.Assets.AssetMetadata> Map( IEnumerable<Dal.Models.AssetMetadata> assetMetadataList );
}