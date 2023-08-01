namespace Domain.Dinner.Entities;

public sealed class Location
{
    public Location(string name, string address, string latitude, string longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    public string Address { get; }
    public string Latitude { get; }
    public string Longitude { get; }
}