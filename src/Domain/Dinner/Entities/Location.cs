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

    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Latitude { get; private set; }
    public string Longitude { get; private set; }
}