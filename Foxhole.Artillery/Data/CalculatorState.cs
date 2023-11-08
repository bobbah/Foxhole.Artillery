namespace Foxhole.Artillery.Data;

public record CalculatorState
{
    public Guid? SessionId;
    public string SessionName = "Artillery Calculator";
    public WindObservation Wind = new();
    public List<FoxholeObservation> ReferencePoints = new();
    public float TargetDistance;
    public float TargetAzimuth;
    public FoxholeObservation TargetReference = FoxholeObservation.Zero;

    public static CalculatorState FromDTO(CalculatorStateDTO dto) => new()
    {
        SessionName = dto.SessionName,
        Wind = dto.Wind,
        ReferencePoints = dto.ReferencePoints,
        TargetDistance = dto.TargetDistance,
        TargetAzimuth = dto.TargetAzimuth,
        TargetReference = dto.TargetReference
    };
}