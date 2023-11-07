using System.Numerics;
using System.Text.Json.Serialization;

namespace Foxhole.Artillery.Data;

public record FoxholeObservation
{
    private const double RadMultiple = Math.PI / 180;
    public float Distance;
    public float Azimuth;
    public string? TextHint;
    public bool IsArtillery;

    [JsonIgnore]
    public Vector2 Vector => new((float)Math.Cos(Azimuth * RadMultiple) * Distance,
        (float)Math.Sin(Azimuth * RadMultiple) * Distance);

    public static FoxholeObservation FromVector(Vector2 vector)
    {
        var distance = (int)Math.Round(vector.Length());
        var angle = (float)(Math.Atan2(vector.Y, vector.X) * (180 / Math.PI));
        if (angle < 0)
            angle += 360;
        return new FoxholeObservation { Azimuth = angle, Distance = distance };
    }

    public override string ToString() => $"{Distance:F2}m, {Azimuth:F1}\u00b0";
}