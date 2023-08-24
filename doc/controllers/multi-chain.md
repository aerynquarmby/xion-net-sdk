# Multi Chain

```csharp
IMultiChainController multiChainController = client.MultiChainController;
```

## Class Name

`MultiChainController`

## Methods

* [Multi-Chain-Single Bill Payment](../../doc/controllers/multi-chain.md#multi-chain-single-bill-payment)
* [Post Approvals](../../doc/controllers/multi-chain.md#post-approvals)


# Multi-Chain-Single Bill Payment

This endpoint is used to make a multi chain single bill payment.

```csharp
MultiChainSingleBillPaymentAsync(
    Models.MultiChainSingleBillPaymentRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`MultiChainSingleBillPaymentRequest`](../../doc/models/multi-chain-single-bill-payment-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.MultiChainSinglePaymentResponse>`](../../doc/models/multi-chain-single-payment-response.md)

## Example Usage

```csharp
try
{
    MultiChainSinglePaymentResponse result = await multiChainController.MultiChainSingleBillPaymentAsync(null);
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
| 401 | Unauthorized | `ApiException` |
| 500 | Internal Server Error | [`ErrorResponseException`](../../doc/models/error-response-exception.md) |


# Post Approvals

This endpoint is used to post approvals.

```csharp
PostApprovalsAsync(
    Models.ApprovalsRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`ApprovalsRequest`](../../doc/models/approvals-request.md) | Body, Optional | - |

## Response Type

`Task`

## Example Usage

```csharp
ApprovalsRequest body = new ApprovalsRequest
{
    DestinationChain = 137,
};

try
{
    await multiChainController.PostApprovalsAsync(body);
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

