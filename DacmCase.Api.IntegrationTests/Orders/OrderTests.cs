using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;

namespace DacmCase.Api.IntegrationTests.Orders;

public class OrderTests : Setup.IntegrationTestBase
{
	private const string ApiPath = "/Api/Order/";
	private const string ApiPathOrderMetadata = $"{ApiPath}Metadata/";

	[Theory]
	[InlineData( Setup.Constants.OrderNumber )]
	public async Task CanGetAssetMetadata( string orderNumber )
	{
		var url = $"{ApiPathOrderMetadata}{orderNumber}";

		var response = await this.HttpClient.GetAsync( url );

		response.StatusCode.Should().Be( HttpStatusCode.OK );
		response.Content.Headers.ContentType!.MediaType.Should().Be( MediaTypeNames.Application.Json );

		var body = await response.Content.ReadAsStringAsync();
		var resultObject = JsonConvert.DeserializeObject<Api.Contracts.Orders.OrderMetadata>( body );

		resultObject.Should().NotBeNull();
		resultObject!.OrderNumber.Should().Be( orderNumber );
	}
}
