namespace Foxhole.Artillery.Data;

public record CalculatorStateDTO
{
    public DateTimeOffset GeneratedAt;
    public AssemblyInformation AppVersion = AssemblyInformation.Current;
    public FoxholeObservation Target = new();
    public WindObservation Wind = new();
    public List<FoxholeObservation> ReferencePoints = new();
    public FiringCharacteristics FiringCharacteristics = new();

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