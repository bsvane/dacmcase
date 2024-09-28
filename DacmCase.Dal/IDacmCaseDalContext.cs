namespace DacmCase.Dal;

public interface IDacmCaseDalContext
{
	// Asset metadata
	Models.AssetMetadata? AssetMetadataGet( string assetId );
	bool AssetMetadataDelete( string assetId );
	List<Models.AssetMetadata> AssetMetadataGetList( IEnumerable<string> assetIds );
	void AssetMetadataInsert( Models.AssetMetadata assetMetadata );
	void AssetMetadataUpdate( Models.AssetMetadata assetMetadata );
	List<Models.AssetMetadata> AssetMetadataGetByBriefIds( IEnumerable<string> briefIds );


	// ContentDistribution
	Models.ContentDistributionMetadata.ContentDistributionMetadataAsset? ContentDistributionAssetGet( string assetId );

	// Orders
	Models.OrderListMetadata? OrderMetadataGet( string orderNumber );
}
