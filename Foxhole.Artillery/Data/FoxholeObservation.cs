using System.Numerics;
using System.Text.Json.Serialization;

namespace Foxhole.Artillery.Data;

public record FoxholeObservation
{
    public static readonly FoxholeObservation Zero = new("Origin", 0, 0, Vector2.Zero);
    private const double RadMultiple = Math.PI / 180;

    public Guid Id = Guid.NewGuid();
    public string Name;
    public Vector2 Location;
    public GunType Artillery;

    [JsonConstructor]
    public FoxholeObservation()
    {
        Name = "Unknown Point";
    }

    public FoxholeObservation(string name, float distance, float azimuth, Vector2 observedPoint)
    {
        Name = name;
        Location = LocationFromObservation(distance, azimuth, observedPoint);
    }

    public FoxholeObservation(string name, float distance, float azimuth, FoxholeObservation observedPoint)
        : this(name, distance, azimuth, observedPoint.Location)
    {
    }

    private static Vector2 LocationFromObservation(float distance, float azimuth, Vector2 observedPoint) =>
        observedPoint + new Vector2((float)Math.Cos(azimuth * RadMultiple) * distance,
            (float)Math.Sin(azimuth * RadMultiple) * distance);
    
    public override string ToString() => Name;

    public string AsObservation()
    {
        var distance = (int)Math.Round(Location.Length());
        var azimuth = (float)(Math.Atan2(Location.Y, Location.X) * (180 / Math.PI));
        if (azimuth < 0)
            azimuth += 360;
        return $"{distance:0}m, {azimuth:0.0}°";
    }
}