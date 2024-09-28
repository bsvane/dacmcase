using DacmCase.Dal;
using static DacmCase.Dal.Models.ContentDistributionMetadata;

namespace DacmCase.Domain.Assets.Handlers;

public class GetAssetUrlHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public GetAssetUrlHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public ContentDistributionMetadataAsset? Execute( string assetId )
	{
		return this.DalContext.ContentDistributionAssetGet( assetId );
	}
}
