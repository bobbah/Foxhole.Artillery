namespace Foxhole.Artillery.Data;

public record CalculatorStateDTO
{
    public DateTimeOffset GeneratedAt;
    public AssemblyInformation AppVersion;
    public FoxholeObservation Target;
    public WindObservation Wind;
    public List<FoxholeObservation> ReferencePoints;
    public FiringCharacteristics FiringCharacteristics;

    public static CalculatorStateDTO FromState(CalculatorState state) =>
        new()
        {
            GeneratedAt = DateTimeOffset.Now,
            AppVersion = AssemblyInformation.Current,
            Target = state.Target,
            Wind = state.Wind,
            ReferencePoints = state.ReferencePoints,
            FiringCharacteristics = state.FiringCharacteristics
        };
}