using DacmCase.Dal;

namespace DacmCase.Domain.Assets.Handlers;

public class AddAssetMetadataHandler
{
	private IDacmCaseDalContext DalContext { get; }

	public AddAssetMetadataHandler( IDacmCaseDalContext databaseContext )
	{
		this.DalContext = databaseContext;
	}

	public void Execute( Dal.Models.AssetMetadata assetMetadata )
	{
		this.DalContext.AssetMetadataInsert( assetMetadata );
	}
}
