namespace Foxhole.Artillery.Data;

public record FiringCharacteristics
{
    /// <summary>
    ///  Type of gun, self-descriptive
    /// </summary>
    public GunType GunType;

    /// <summary>
    /// The range step in meters, this is how much the gun can increment/decrement the range
    /// </summary>
    public float RangeStep = 1.0f;

    /// <summary>
    /// The minimum firing range, in meters
    /// </summary>
    public int MinRange;

    /// <summary>
    /// The maximum firing range, in meters
    /// </summary>
    public int MaxRange;

    /// <summary>
    /// The magnitude that each level of wind effects the gun, from level 1-5
    /// </summary>
    public float[] WindOffsetMagnitude = new float[5] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };

    public static FiringCharacteristics FromType(GunType type)
    {
        return type switch
        {
            GunType.WardenHowitzer120 => new FiringCharacteristics
            {
                GunType = type,
                RangeStep = 8,
                MinRange = 100,
                MaxRange = 300,
                WindOffsetMagnitude = new[] { 15.0f, 30.0f, 45.0f, 60.0f, 75.0f }
            },
            GunType.WardenHowitzer150 => new FiringCharacteristics
            {
                GunType = type,
                RangeStep = 8,
                MinRange = 100,
                MaxRange = 300,
                WindOffsetMagnitude = new[] { 15.0f, 30.0f, 45.0f, 60.0f, 75.0f }
            },
            GunType.Mortar => new FiringCharacteristics
            {
                GunType = type,
                RangeStep = 0.5f,
                MinRange = 45,
                MaxRange = 80
            },
            GunType.WardenGunboat => new FiringCharacteristics
            {
                GunType = type,
                RangeStep = 10 / 6.0f,
                MinRange = 75,
                MaxRange = 100
            },
            GunType.CollieHowitzer120 => new FiringCharacteristics()
            {
                GunType = type,
                RangeStep = 8.0f, // not sure...?
                MinRange = 100,
                MaxRange = 300,
                WindOffsetMagnitude = new[] { 12.0f, 24.0f, 36.0f, 48.0f, 60.0f }
            },
            GunType.CollieHowitzer150 => new FiringCharacteristics()
            {
                GunType = type,
                RangeStep = 8.0f, // not sure...?
                MinRange = 200,
                MaxRange = 350,
                WindOffsetMagnitude = new[] { 18.0f, 36.0f, 54.0f, 72.0f, 90.0f }
            },
            GunType.Unknown => new FiringCharacteristics()
            {
                GunType = type
            },
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}