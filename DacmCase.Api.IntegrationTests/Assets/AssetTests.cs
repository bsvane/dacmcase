using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;

namespace DacmCase.Api.IntegrationTests.Assets;

public class AssetTests : Setup.IntegrationTestBase
{
	private const string ApiPath = "/Api/Asset/";
	private const string ApiPathAssetMetadata = $"{ApiPath}Metadata/";

	[Theory]
	[InlineData( Setup.Constants.AssetId )]
	public async Task CanGetAssetMetadata( string assetId )
	{
		var url = $"{ApiPathAssetMetadata}{assetId}";

		var response = await this.HttpClient.GetAsync( url );

		response.StatusCode.Should().Be( HttpStatusCode.OK );
		response.Content.Headers.ContentType!.MediaType.Should().Be( MediaTypeNames.Application.Json );

		var body = await response.Content.ReadAsStringAsync();
		var resultObject = JsonConvert.DeserializeObject<Api.Contracts.Assets.AssetMetadata>( body );

		resultObject.Should().NotBeNull();
		resultObject!.AssetId.Should().Be( assetId );
	}

	// Integration test for AddMetadata goes here...

	// Integration test for UpdateMetadata goes here...

	// Integration test for DeleteMetadata goes here...

	// Integration test for GetAssetUrl goes here...
}
