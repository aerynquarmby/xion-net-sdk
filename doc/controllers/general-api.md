# General API

```csharp
IGeneralAPIController generalAPIController = client.GeneralAPIController;
```

## Class Name

`GeneralAPIController`


# Health

This endpoint is used to check the health of the API.

```csharp
HealthAsync()
```

## Response Type

`Task<string>`

## Example Usage

```csharp
try
{
    string result = await generalAPIController.HealthAsync();
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
| 500 | Internal Server Error | `ApiException` |

