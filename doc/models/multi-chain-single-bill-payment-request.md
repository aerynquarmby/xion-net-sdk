
# Multi Chain Single Bill Payment Request

## Structure

`MultiChainSingleBillPaymentRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProductName` | `string` | Optional | Name of the product. |
| `AmountUSD` | `double?` | Optional | Amount to be paid (USD). |
| `Token` | `string` | Optional | Token of the amount to paid. |
| `BuyerAddress` | `string` | Optional | Buyer's wallet address. |
| `Chain` | `double?` | Optional | Chain to be used for payment. |

## Example (as JSON)

```json
{
  "productName": "productName0",
  "amountUSD": 118.92,
  "token": "token6",
  "buyerAddress": "buyerAddress8",
  "chain": 161.78
}
```

