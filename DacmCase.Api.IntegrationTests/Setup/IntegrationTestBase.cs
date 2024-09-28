namespace DacmCase.Api.IntegrationTests.Setup;

public class IntegrationTestBase
{
	//private const string ObjectIdentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";
	//private const string NameIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
	//private const string TFP = "tfp";
	//private const string Scope = "http://schemas.microsoft.com/identity/claims/scope";

	protected HttpClient HttpClient { get; }

	protected IntegrationTestBase()
	{
		this.HttpClient = new HttpClient();
		this.HttpClient.BaseAddress = new Uri( Constants.HttpBaseAddress );

		//var claims = new Dictionary<string, object>
		//	{
		//		{ObjectIdentifier, Constants.HttpIdentityId},
		//		{NameIdentifier, Constants.HttpIdentityId},
		//		{TFP, Constants.HttpTfp},
		//		{Scope, Constants.HttpScope}
		//	};

		//HttpClient.SetFakeBearerToken( claims );
	}
}
