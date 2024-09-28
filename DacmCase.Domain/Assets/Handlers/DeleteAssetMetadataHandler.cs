using DacmCase.Dal;

namespace DacmCase.Domain.Assets.Handlers;

public class DeleteAssetMetadataHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public DeleteAssetMetadataHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public bool Execute( string assetId )
	{
		return this.DalContext.AssetMetadataDelete( assetId );
	}
}
