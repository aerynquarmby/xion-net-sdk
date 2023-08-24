# Merchant

```csharp
IMerchantController merchantController = client.MerchantController;
```

## Class Name

`MerchantController`

## Methods

* [Register Master Merchant](../../doc/controllers/merchant.md#register-master-merchant)
* [Register Sub Merchant](../../doc/controllers/merchant.md#register-sub-merchant)


# Register Master Merchant

This endpoint is used to register master merchant.

```csharp
RegisterMasterMerchantAsync(
    Models.RegisterMasterMerchantRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`RegisterMasterMerchantRequest`](../../doc/models/register-master-merchant-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.MerchantTokenResponse>`](../../doc/models/merchant-token-response.md)

## Example Usage

```csharp
try
{
    MerchantTokenResponse result = await merchantController.RegisterMasterMerchantAsync(null);
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


# Register Sub Merchant

This endpoint is used to register sub merchant.

```csharp
RegisterSubMerchantAsync(
    Models.RegisterSubMerchantRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`RegisterSubMerchantRequest`](../../doc/models/register-sub-merchant-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.MerchantTokenResponse>`](../../doc/models/merchant-token-response.md)

## Example Usage

```csharp
try
{
    MerchantTokenResponse result = await merchantController.RegisterSubMerchantAsync(null);
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

