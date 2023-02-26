using SlotMachineApp.Contracts;
using System;
using System.Collections.Generic;

namespace SlotMachineApp
{
    public class SlotMachine : ISlotMachine
    {
        private readonly IConsole console;
        private readonly ISlotMachineService slotMachineService;
        private readonly List<ISymbol> symbols;
        private char[,] table;
        private decimal balance;
        private decimal stake;

        public SlotMachine(IConsole console, ISlotMachineService slotMachineService, List<ISymbol> symbols, decimal balance, decimal stake)
        {
            this.table = new char[4, 3];
            this.console = console;
            this.slotMachineService = slotMachineService;
            this.symbols = symbols;
            this.balance = balance;
            this.stake = stake;
        }

        public void Start()
        {
            try
            {
                this.console.WriteLine("Welcome to Slot Machine App!");
                this.console.Write("Enter your initial deposit amount: $");

                this.balance = decimal.Parse(this.console.ReadLine());
                while (this.balance > 0)
                {
                    this.console.Write("Enter stake amount: $");
                    this.stake = decimal.Parse(this.console.ReadLine());

                    if (this.stake > this.balance)
                    {
                        this.console.WriteLine("Stake amount cannot be greater than your deposit balance!");
                        continue;
                    }

                    this.table = this.slotMachineService.SpinSymbols(this.symbols, this.table);
                    this.DisplayTable();

                    decimal win = this.slotMachineService.CalculateWin(this.table, this.symbols, this.stake);
                    this.balance = this.slotMachineService.CalculateTotalBalance(this.balance, win, this.stake);

                    this.console.WriteLine("========== RESULTS ==========");
                    this.console.WriteLine($"Win amount: ${win}");
                    this.console.WriteLine($"Total balance: ${this.balance}");
                    this.console.WriteLine("");
                }

                this.console.WriteLine("Game over.");
            }
            catch (Exception)
            {
                this.console.WriteLine("XXXXXXXXXXXXXX");
                this.console.WriteLine("You have entered invalid amount!");
                this.console.WriteLine("Please enter valid number!");
                this.console.WriteLine("");
                this.Start();
            }
        }

        private void DisplayTable()
        {
            this.console.WriteLine("-------------");
            for (int row = 0; row < 4; row++)
            {
                this.console.Write("| ");
                for (int col = 0; col < 3; col++)
                {
                    this.console.Write(this.table[row, col] + " | ");
                }
                this.console.WriteLine("");
                this.console.WriteLine("-------------");
            }
        }
    }
}
