# Auth

```csharp
IAuthController authController = client.AuthController;
```

## Class Name

`AuthController`

## Methods

* [Delete Client App](../../doc/controllers/auth.md#delete-client-app)
* [Get Client Ids](../../doc/controllers/auth.md#get-client-ids)
* [Register](../../doc/controllers/auth.md#register)


# Delete Client App

This endpoint is used to delete a registered client app.

```csharp
DeleteClientAppAsync(
    string merchantWalletAddress,
    string clientId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `merchantWalletAddress` | `string` | Template, Required | - |
| `clientId` | `string` | Template, Required | - |

## Response Type

`Task<string>`

## Example Usage

```csharp
string merchantWalletAddress = "merchantWalletAddress6";
string clientId = "clientId6";
try
{
    string result = await authController.DeleteClientAppAsync(merchantWalletAddress, clientId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |
| 500 | Internal Server Error | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |


# Get Client Ids

This endpoint is used to get a list of client Ids created by the merchant.

```csharp
GetClientIdsAsync(
    string merchantWalletAddress)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `merchantWalletAddress` | `string` | Template, Required | - |

## Response Type

[`Task<Models.ListClientAppsResponse>`](../../doc/models/list-client-apps-response.md)

## Example Usage

```csharp
string merchantWalletAddress = "merchantWalletAddress6";
try
{
    ListClientAppsResponse result = await authController.GetClientIdsAsync(merchantWalletAddress);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |
| 500 | Internal Server Error | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |


# Register

This endpoint is used to register a new client access.

```csharp
RegisterAsync(
    Models.RegisterTokenRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`RegisterTokenRequest`](../../doc/models/register-token-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.RegisterTokenResponse>`](../../doc/models/register-token-response.md)

## Example Usage

```csharp
try
{
    RegisterTokenResponse result = await authController.RegisterAsync(null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |
| 500 | Internal Server Error | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |

