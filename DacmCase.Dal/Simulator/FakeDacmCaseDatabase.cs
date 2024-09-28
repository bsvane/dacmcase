using DacmCase.Dal.Models;
using Newtonsoft.Json;

namespace DacmCase.Dal.Simulator;

internal static class FakeDacmCaseDatabase
{
	internal static List<AssetMetadata> AssetMetadataList { get; set; } = new();
	internal static List<BriefingMetadata> BriefingMetadataList { get; set; } = new();
	internal static ContentDistributionMetadata ContentDistributionMetadata { get; set; } = new();
	internal static List<OrderListMetadata> OrderListMetadataList { get; set; } = new();

	// Missing link (This is just one possible link between Brief and Asset, could be an endless amount of other ways)
	internal static List<BriefingAssetMetadata> BriefingAssetMetadataList { get; set; } = new();

	internal static void Load()
	{
		AssetMetadataList = GetResourceAsCollection<List<AssetMetadata>>( "AssetMetadata.json" );
		BriefingMetadataList = GetResourceAsCollection<List<BriefingMetadata>>( "BriefingMetadata.json" );
		ContentDistributionMetadata = GetResourceAsCollection<ContentDistributionMetadata>( "ContentDistributionMetadata.json" );
		OrderListMetadataList = GetResourceAsCollection<List<OrderListMetadata>>( "OrderListMetadata.json" );
		BriefingAssetMetadataList = GetResourceAsCollection<List<BriefingAssetMetadata>>( "BriefingAssetMetadata.json" );
	}

	private static T GetResourceAsCollection<T>( string resourceName )
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		var assetMetadataResourceName = assembly.GetManifestResourceNames().First( o => o.Contains( $".{resourceName}" ) );

		using var stream = assembly.GetManifestResourceStream( assetMetadataResourceName )!;
		using var reader = new StreamReader( stream );
		var resourceContent = reader.ReadToEnd();

		return JsonConvert.DeserializeObject<T>( resourceContent )!;
	}
}
