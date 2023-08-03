namespace Contracts.Menus;

public record MenuResponse
(
    Guid Id,
    string Name,
    string Description,
    AverageRating? AverageRating,
    List<MenuSectionResponse> Sections,
    Guid HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);

public record AverageRating
(
    int NumRatings,
    double Value);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description);
