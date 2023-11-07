namespace Foxhole.Artillery.Data;

public record FiringVector
{
    /// <summary>
    /// If the calculated vector is constrained by the limits of the firing profile
    /// </summary>
    public bool IsLimited;

    /// <summary>
    /// The final vector after being processed to match the firing profile
    /// </summary>
    public FoxholeObservation FinalVector;
    
    /// <summary>
    /// The firing vector before being limited and rounded
    /// </summary>
    public FoxholeObservation UnlimitedVector;
}