# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Yummy Menu",
  "description": "This is a yummy menu",
  "averageRating": 0.0,
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Yummy Section",
      "description": "This is a yummy section",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Yummy Item",
          "description": "This is a yummy item",
          "price": 0.0,
          "isAvailable": true
        }
      ]
    }
  ],
  "createdDateTime": "0001-01-01T00:00:00.000Z",
  "updatedDateTime": "0001-01-01T00:00:00.000Z",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": ["00000000-0000-0000-0000-000000000000"],
  "menuReviewIds": ["00000000-0000-0000-0000-000000000000"]
}
```
