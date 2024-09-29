# DACM Case

This example illustrates the basic layout of an application accessing digital assets through a REST API.

Presentation: https://docs.google.com/presentation/d/1riD-8N444RYFsHbou4BXgd3jWb4ylE8KDEXDi8kRd54/edit?usp=sharing

## Comments

A lot of assumptions and decisions have been made.

## Solution

Microsoft Visual Studio Solution containing the following .Net 8 projects, written in C# with nullable reference types and implicit usings:
* DacmCase.Api - ASP.NET Minimal Web API project.
	* Running in Docker
	* Swagger
	* .http file for easy access
* DacmCase.Api.Contracts - Library project containing the public contracts for the API
* DacmCase.Api.IntegrationTests - Unit test (XUnit) project. Contains integration tests for the API
* DacmCase.Api.Mapping - Library project for the API contract mapping
* DacmCase.Api.Mapping.Tests - Unit test (XUnit) project. Contains unit tests for the API contract mapping layer
* DacmCase.Dal - Data Access Layer. Contains a simulated database
* DacmCase.Domain - Library project for the Domain Layer
* DacmCase.Domain.Tests - Unit test (XUnit) project. Contains unit tests for the Domain layer

## Missing

* Credentials and permissions are not implemented in the solution. This could be handled using JWT, API Keys, etc. and be as granular as needed.
* Versioning is not implemented
* In a real-world scenario, we would use a framework with decorations and templates, for a unified implementation.
* The DAL is simulated using the provided json files

## API Routes

### Assets

I have made a route for Assets, with the basic operations (GET, POST, PUT, DELETE). This is obviously only for the ease of example and shows how requests are handled through the layers.

* /Api/Asset/Metadata/{assetId} (GET) (```ASSET001```)
* /Api/Asset/Metadata/{assetId}/Url (GET)
* /Api/Asset/Metadata/ (POST)
* /Api/Asset/Metadata/ (PUT)
* /Api/Asset/Metadata/{assetId} (DELETE)

### Orders

I have made one endpoint (GET) for Orders. This returns the most basic order data and linked assets (Shows that the missing data link is implemented)

* /Api/Order/Metadata/{orderNumber} (GET) (```ORD123456789```)
