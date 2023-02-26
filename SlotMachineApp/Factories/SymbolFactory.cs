using SlotMachineApp.Contracts;
using SlotMachineApp.Models;
using System.Collections.Generic;

namespace SlotMachineApp.Factories
{
    public static class SymbolFactory
    {
        public static List<ISymbol> CreateSymbols()
        {
            return new List<ISymbol>()
            {
                new Symbol { Name = 'A', Coefficient = 0.4, ProbabilityPercentile = 0.45 },
                new Symbol { Name = 'B', Coefficient = 0.6, ProbabilityPercentile = 0.35 },
                new Symbol { Name = 'P', Coefficient = 0.8, ProbabilityPercentile = 0.15 },
                new Symbol { Name = '*', Coefficient = 0, ProbabilityPercentile = 0.05 }
            };
        }
    }
}
