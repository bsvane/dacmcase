using DacmCase.Dal.Exceptions;
using DacmCase.Domain.Assets.Handlers;
using Microsoft.AspNetCore.Mvc;
using DacmCase.Api.Mapping.Assets;

namespace DacmCase.Api.Controllers;

[ApiController]
[Route( "Api/[controller]" )]
public class AssetController(
	GetAssetMetadataHandler getAssetMetadataHandler,
	AddAssetMetadataHandler addAssetMetadataHandler,
	UpdateAssetMetadataHandler updateAssetMetadataHandler,
	DeleteAssetMetadataHandler deleteAssetMetadataHandler,
	GetAssetUrlHandler getAssetUrlHandler,
	IAssetMapper assetMapper,
	ILogger<AssetController> logger ) : ControllerBase
{
	private GetAssetMetadataHandler GetAssetMetadataHandler { get; } = getAssetMetadataHandler;
	private AddAssetMetadataHandler AddAssetMetadataHandler { get; } = addAssetMetadataHandler;
	private UpdateAssetMetadataHandler UpdateAssetMetadataHandler { get; } = updateAssetMetadataHandler;
	public DeleteAssetMetadataHandler DeleteAssetMetadataHandler { get; } = deleteAssetMetadataHandler;
	public GetAssetUrlHandler GetAssetUrlHandler { get; } = getAssetUrlHandler;

	private IAssetMapper AssetMapper { get; } = assetMapper;
	private ILogger<AssetController> Logger { get; } = logger;

	[HttpGet( "Metadata/{assetId}" )]
	public ActionResult<Api.Contracts.Assets.AssetMetadata> GetAssetMetadata( string assetId )
	{
		var assetMetadata = this.GetAssetMetadataHandler.Execute( assetId );
		if ( assetMetadata is null )
		{
			return this.NotFound();
		}

		var mappedAssetMetadata = this.AssetMapper.Map( assetMetadata );

		return this.Ok( mappedAssetMetadata );
	}

	[HttpPost( "Metadata" )]
	public ActionResult AddAssetMetadata( Api.Contracts.Assets.AssetMetadata assetMetadata )
	{
		var mappedAssetMetadata = this.AssetMapper.Map( assetMetadata );

		try
		{
			this.AddAssetMetadataHandler.Execute( mappedAssetMetadata );
		}
		catch ( DuplicateKeyException e )
		{
			this.Logger.LogError( e, "AddAssetMetadata" );
			return this.UnprocessableEntity();
		}

		return this.Created();
	}

	[HttpPut( "Metadata" )]
	public ActionResult UpdateAssetMetadata( Api.Contracts.Assets.AssetMetadata assetMetadata )
	{
		var mappedAssetMetadata = this.AssetMapper.Map( assetMetadata );

		try
		{
			this.UpdateAssetMetadataHandler.Execute( mappedAssetMetadata );
		}
		catch ( NotFoundException e )
		{
			this.Logger.LogError( e, "UpdateAssetMetadata" );
			return this.UnprocessableEntity();
		}

		return this.Ok();
	}

	[HttpDelete( "Metadata/{assetId}" )]
	public ActionResult DeleteAssetMetadata( string assetId )
	{
		var deletedSuccessfully = this.DeleteAssetMetadataHandler.Execute( assetId );

		return deletedSuccessfully
			? this.Ok()
			: this.NotFound();
	}

	[HttpGet( "{assetId}/Url" )]
	public ActionResult<string?> GetAssetUrl( string assetId )
	{
		var contentDistributionAsset = this.GetAssetUrlHandler.Execute( assetId );
		if ( contentDistributionAsset is null )
		{
			return this.NotFound();
		}

		if ( string.IsNullOrEmpty( contentDistributionAsset.fileURL ) )
		{
			return this.UnprocessableEntity();
		}

		return this.Ok( contentDistributionAsset.fileURL );
	}
}
