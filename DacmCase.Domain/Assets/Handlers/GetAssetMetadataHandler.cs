using DacmCase.Dal;

namespace DacmCase.Domain.Assets.Handlers;

public class GetAssetMetadataHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public GetAssetMetadataHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public Dal.Models.AssetMetadata? Execute( string assetId )
	{
		return this.DalContext.AssetMetadataGet( assetId );
	}
}
