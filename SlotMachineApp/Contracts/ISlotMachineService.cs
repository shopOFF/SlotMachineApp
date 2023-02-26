using System.Collections.Generic;

namespace SlotMachineApp.Contracts
{
    public interface ISlotMachineService
    {
        char[,] SpinSymbols(List<ISymbol> symbols, char[,] table);
        decimal CalculateWin(char[,] table, List<ISymbol> symbols, decimal stake);
        decimal GetCoefficient(char symbol, List<ISymbol> symbols);
        decimal CalculateTotalBalance(decimal balance, decimal win, decimal stake);
    }
}
