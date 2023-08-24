# Single Bill Payments

```csharp
ISingleBillPaymentsController singleBillPaymentsController = client.SingleBillPaymentsController;
```

## Class Name

`SingleBillPaymentsController`

## Methods

* [Get Order Status](../../doc/controllers/single-bill-payments.md#get-order-status)
* [Single Bill Payment](../../doc/controllers/single-bill-payments.md#single-bill-payment)


# Get Order Status

This endpoint is used to get the status of an order.

```csharp
GetOrderStatusAsync(
    string orderCode)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderCode` | `string` | Template, Required | - |

## Response Type

`Task<string>`

## Example Usage

```csharp
string orderCode = "orderCode8";
try
{
    string result = await singleBillPaymentsController.GetOrderStatusAsync(orderCode);
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


# Single Bill Payment

This endpoint is used to make a single bill payment.

```csharp
SingleBillPaymentAsync(
    Models.SingleBillPaymentRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SingleBillPaymentRequest`](../../doc/models/single-bill-payment-request.md) | Body, Optional | - |

## Response Type

[`Task<Models.SingleBillPaymentResponse>`](../../doc/models/single-bill-payment-response.md)

## Example Usage

```csharp
try
{
    SingleBillPaymentResponse result = await singleBillPaymentsController.SingleBillPaymentAsync(null);
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

