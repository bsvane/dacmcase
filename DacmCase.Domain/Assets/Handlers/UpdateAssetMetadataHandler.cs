using DacmCase.Dal;

namespace DacmCase.Domain.Assets.Handlers;

public class UpdateAssetMetadataHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public UpdateAssetMetadataHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public void Execute( Dal.Models.AssetMetadata assetMetadata )
	{
		this.DalContext.AssetMetadataUpdate( assetMetadata );
	}
}
