namespace Foxhole.Artillery.Data;

public record FiringCharacteristics
{
    public GunType GunType;
    public float RangeStep;
    public int MinRange;
    public int MaxRange;

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
            },
            GunType.WardenHowitzer150 => new FiringCharacteristics
            {
                GunType = type,
                RangeStep = 8,
                MinRange = 100,
                MaxRange = 300,
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
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}