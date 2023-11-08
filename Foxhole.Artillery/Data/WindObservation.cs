using System.Numerics;

namespace Foxhole.Artillery.Data;

public enum WindLevel
{
    One,
    Two,
    Three,
    Four,
    Five
}

public record WindObservation
{
    public WindLevel Level;
    public float WindAzimuth;

    public Vector2 CalculateOffset(FiringCharacteristics firingCharacteristics)
    {
        // We can just use an observation under the hood for this, it's basically what the wind is
        var obs = new FoxholeObservation("Wind", firingCharacteristics.WindOffsetMagnitude[(int)Level], WindAzimuth,
            Vector2.Zero);
        return -obs.Location;
    }
}