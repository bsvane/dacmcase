using DacmCase.Dal.Exceptions;

namespace DacmCase.Dal;

// This class is just a mock-up, obviously this will never do in a real environment and is not distributed

public class DacmCaseDalContext : IDacmCaseDalContext
{
	public DacmCaseDalContext()
	{
		Simulator.FakeDacmCaseDatabase.Load();
	}

	// Asset
	public Models.AssetMetadata? AssetMetadataGet( string assetId )
	{
		return Simulator.FakeDacmCaseDatabase.AssetMetadataList
			.FirstOrDefault( assetMetadata => assetMetadata.assetId == assetId );
	}

	public List<Models.AssetMetadata> AssetMetadataGetList( IEnumerable<string> assetIds )
	{
		return Simulator.FakeDacmCaseDatabase.AssetMetadataList
			.Where( assetMetadata => assetIds.Contains( assetMetadata.assetId ) )
			.ToList();
	}

	public void AssetMetadataInsert( Models.AssetMetadata assetMetadata )
	{
		if ( Simulator.FakeDacmCaseDatabase.AssetMetadataList.Any( srcAssetMetadata => srcAssetMetadata.assetId == assetMetadata.assetId ) )
		{
			throw new DuplicateKeyException();
		}

		Simulator.FakeDacmCaseDatabase.AssetMetadataList.Add( assetMetadata );
	}

	public void AssetMetadataUpdate( Models.AssetMetadata assetMetadata )
	{
		var index = Simulator.FakeDacmCaseDatabase.AssetMetadataList
			.FindIndex( srcAssetMetadata => srcAssetMetadata.assetId == assetMetadata.assetId );

		if ( index < 0 )
		{
			throw new NotFoundException();
		}

		Simulator.FakeDacmCaseDatabase.AssetMetadataList[index] = assetMetadata;
	}

	public bool AssetMetadataDelete( string assetId )
	{
		return Simulator.FakeDacmCaseDatabase.AssetMetadataList
			.RemoveAll( assetMetadata => assetMetadata.assetId == assetId ) >= 1;
	}

	public List<Models.AssetMetadata> AssetMetadataGetByBriefIds( IEnumerable<string> briefIds )
	{
		var briefingAssetIds = Simulator.FakeDacmCaseDatabase.BriefingAssetMetadataList
			.Where( briefingAsset => briefIds.Contains( briefingAsset.briefId ) && briefingAsset.assetIds is not null )
			.SelectMany( briefingAsset => briefingAsset.assetIds! );

		return Simulator.FakeDacmCaseDatabase.AssetMetadataList
			.Where( assetMetadata => briefingAssetIds.Contains( assetMetadata.assetId ) )
			.ToList();
	}

	// ContentDistribution
	public Models.ContentDistributionMetadata.ContentDistributionMetadataAsset? ContentDistributionAssetGet( string assetId )
	{
		return Simulator.FakeDacmCaseDatabase.ContentDistributionMetadata.assets!
			.FirstOrDefault( contentDistributionMetadataAsset => contentDistributionMetadataAsset.assetId == assetId );
	}

	// Order
	public Models.OrderListMetadata? OrderMetadataGet( string orderNumber )
	{
		return Simulator.FakeDacmCaseDatabase.OrderListMetadataList!
			.FirstOrDefault( orderListMetadata => orderListMetadata.orderNumber == orderNumber );
	}
}
