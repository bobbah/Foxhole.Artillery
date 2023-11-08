namespace Foxhole.Artillery.Data;

public record CalculatorStateDTO
{
    public DateTimeOffset GeneratedAt;
    public AssemblyInformation AppVersion = AssemblyInformation.Current;
    public string SessionName = "Artillery Calculator";
    public WindObservation Wind = new();
    public List<FoxholeObservation> ReferencePoints = new();
    public float TargetDistance;
    public float TargetAzimuth;
    public FoxholeObservation TargetReference = FoxholeObservation.Zero;

    public static CalculatorStateDTO FromState(CalculatorState state) =>
        new()
        {
            GeneratedAt = DateTimeOffset.Now,
            AppVersion = AssemblyInformation.Current,
            SessionName =  state.SessionName,
            Wind = state.Wind,
            ReferencePoints = state.ReferencePoints,
            TargetDistance = state.TargetDistance,
            TargetAzimuth = state.TargetAzimuth,
            TargetReference = state.TargetReference
        };
}