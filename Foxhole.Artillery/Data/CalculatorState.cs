namespace Foxhole.Artillery.Data;

public record CalculatorState
{
    public Guid? SessionId;
    public FoxholeObservation Target = new();
    public WindObservation Wind = new();
    public List<FoxholeObservation> ReferencePoints = new();
    public FiringCharacteristics FiringCharacteristics = new();

    public static CalculatorState FromDTO(CalculatorStateDTO dto) => new()
    {
        Target = dto.Target,
        Wind = dto.Wind,
        ReferencePoints = dto.ReferencePoints,
        FiringCharacteristics = dto.FiringCharacteristics
    };
}