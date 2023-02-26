using SlotMachineApp.Contracts;

namespace SlotMachineApp.Models
{
    public class Symbol : ISymbol
    {
        public char Name { get; set; }
        public double Coefficient { get; set; }
        public double ProbabilityPercentile { get; set; }
    }
}
