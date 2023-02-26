using SlotMachineApp.Contracts;
using System;
using System.Collections.Generic;

namespace SlotMachineApp.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        public char[,] SpinSymbols(List<ISymbol> symbols, char[,] table)
        {
            Random random = new Random();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    double rnd = random.NextDouble();
                    double cumulativeProbability = 0;
                    foreach (var symbol in symbols)
                    {
                        cumulativeProbability += symbol.ProbabilityPercentile;
                        if (rnd < cumulativeProbability)
                        {
                            table[row, col] = symbol.Name;
                            break;
                        }
                    }
                }
            }

            return table;
        }

        public decimal CalculateWin(char[,] table, List<ISymbol> symbols, decimal stake)
        {
            decimal win = 0;
            for (int row = 0; row < 4; row++)
            {
                char symbol = table[row, 0];
                if (symbol == '*' || symbol == table[row, 1] && symbol == table[row, 1] && symbol == table[row, 2])
                {
                    decimal coefficient = 0;
                    for (int col = 0; col < 3; col++)
                    {
                        if (table[row, col] != '*')
                        {
                            symbol = table[row, col];
                            coefficient += this.GetCoefficient(symbol, symbols);
                        }
                    }

                    win += coefficient * stake;
                }
            }

            return win;
        }

        public decimal GetCoefficient(char symbol, List<ISymbol> symbols)
        {
            foreach (var sym in symbols)
            {
                if (sym.Name == symbol)
                {
                    return Convert.ToDecimal(sym.Coefficient);
                }
            }

            return 0;
        }

        public decimal CalculateTotalBalance(decimal balance, decimal win, decimal stake)
        {
            if (balance < stake)
            {
                throw new ArgumentException("Stake amount cannot be greater than your deposit balance!");
            }

            return balance + win - stake;
        }
    }
}
