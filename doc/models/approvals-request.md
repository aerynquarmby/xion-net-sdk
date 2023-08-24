
# Approvals Request

## Structure

`ApprovalsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `int?` | Optional | ID of product. |
| `SourceUserAddress` | `string` | Optional | Wallet address of buyer. |
| `SourceChain` | `int?` | Optional | Chain ID for making the approvals. |
| `SourceToken` | `string` | Optional | Token used for approvals. |
| `DestinationUserAddress` | `string` | Optional | Wallet address of merchant. |
| `DestinationChain` | `int?` | Optional | Chain ID for polygon matic mainnet.<br>**Default**: `137` |
| `DestinationToken` | `string` | Optional | Token used for approvals. |
| `AmountUSD` | `double?` | Optional | Amount to be paid (USD). |
| `Products` | `List<double>` | Optional | List of product Ids. |

## Example (as JSON)

```json
{
  "destinationChain": 137,
  "id": 112,
  "sourceUserAddress": "sourceUserAddress0",
  "sourceChain": 254,
  "sourceToken": "sourceToken4",
  "destinationUserAddress": "destinationUserAddress8"
}
```

