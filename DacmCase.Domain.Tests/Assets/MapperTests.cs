using DacmCase.Api.Contracts.Assets;

namespace DacmCase.Domain.Tests.Assets;

public class MapperTests
{
	[Theory]
	[AutoData]
	public void Should_Map_AssetMetadata_ToContract( Dal.Models.AssetMetadata assetMetadata )
	{
		// Arrange
		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();

		result.Should().BeEquivalentTo( assetMetadata, src => src
			.Excluding( o => o.assetId )
			.Excluding( o => o.name )
			.Excluding( o => o.description )
			.Excluding( o => o.fileFormat )
			.Excluding( o => o.fileSize )
			.Excluding( o => o.createdBy )
			.Excluding( o => o.VersionNumber )
			.Excluding( o => o.path )
			.Excluding( o => o.Preview )
			.Excluding( o => o.Status )
			);

		result.AssetId.Should().Be( assetMetadata.assetId );
		result.Name.Should().Be( assetMetadata.name );
		result.Description.Should().Be( assetMetadata.description );
		result.FileFormat.Should().Be( assetMetadata.fileFormat );
		result.FileSize.Should().BeNull();
		result.CreatedBy.Should().Be( assetMetadata.createdBy );
		result.VersionNumber.Should().BeNull();
		result.Path.Should().Be( assetMetadata.path );
		result.PathPreview.Should().Be( assetMetadata.Preview );
		result.Status.Should().BeNull();
	}

	[Theory]
	[AutoData]
	public void Should_Map_AssetMetadata_ToContract_FileSize( Dal.Models.AssetMetadata assetMetadata, int fileSize )
	{
		// Arrange
		assetMetadata.fileSize = fileSize.ToString();

		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();
		result.FileSize.Should().HaveValue().And.Be( fileSize );
	}

	[Theory]
	[AutoData]
	public void Should_Map_AssetMetadata_ToContract_VersionNumber( Dal.Models.AssetMetadata assetMetadata, byte majorVersion, byte minorVersion )
	{
		// Arrange
		assetMetadata.VersionNumber = $"{majorVersion}.{minorVersion}";

		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();
		result.VersionNumber.Should().NotBeNull().And.BeEquivalentTo( new Version( majorVersion, minorVersion ) );
	}

	[Theory]
	[InlineAutoData( AssetStatus.Approved )]
	public void Should_Map_AssetMetadata_ToContract_Status( AssetStatus assetStatus, Dal.Models.AssetMetadata assetMetadata )
	{
		// Arrange
		assetMetadata.Status = assetStatus.ToString();

		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();
		result.Status.Should().HaveValue().And.Be( assetStatus );
	}

	[Theory]
	[InlineAutoData( "ToBeDefined" )]
	public void Should_Map_AssetMetadata_ToContract_FileFormat_TBD( string fileFormat, Dal.Models.AssetMetadata assetMetadata )
	{
		// Arrange
		assetMetadata.fileFormat = fileFormat;

		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();
		result.FileFormat.Should().BeNull();
	}

	[Theory]
	[AutoData]
	public void Should_Map_AssetMetadata_FromContract( Api.Contracts.Assets.AssetMetadata assetMetadata )
	{
		// Arrange
		var mapper = new Domain.Assets.Mapper();

		// Act
		var result = mapper.Map( assetMetadata );

		// Assert
		result.Should().NotBeNull();

		result.Should().BeEquivalentTo( assetMetadata, src => src
			.Excluding( o => o.AssetId )
			.Excluding( o => o.Name )
			.Excluding( o => o.Description )
			.Excluding( o => o.FileFormat )
			.Excluding( o => o.FileSize )
			.Excluding( o => o.CreatedBy )
			.Excluding( o => o.VersionNumber )
			.Excluding( o => o.Path )
			.Excluding( o => o.PathPreview )
			.Excluding( o => o.Status )
			);

		result.assetId.Should().Be( assetMetadata.AssetId );
		result.name.Should().Be( assetMetadata.Name );
		result.description.Should().Be( assetMetadata.Description );
		result.fileFormat.Should().Be( assetMetadata.FileFormat );
		result.fileSize.Should().Be( assetMetadata.FileSize.ToString() );
		result.createdBy.Should().Be( assetMetadata.CreatedBy );
		result.VersionNumber.Should().Be( $"{assetMetadata.VersionNumber!.Major}.{assetMetadata.VersionNumber!.Minor}" );
		result.path.Should().Be( assetMetadata.Path );
		result.Preview.Should().Be( assetMetadata.PathPreview );
		result.Status.Should().Be( Setup.Constants.ToBeDefinedPlaceholder );
	}
}
