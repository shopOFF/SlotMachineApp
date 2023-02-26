namespace SlotMachineApp.Contracts
{
    public interface ISymbol
    {
        char Name { get; }
        double Coefficient { get; }
        double ProbabilityPercentile { get; }
    }
}
