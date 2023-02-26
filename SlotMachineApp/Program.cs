using Microsoft.Extensions.DependencyInjection;
using SlotMachineApp.Contracts;
using SlotMachineApp.Factories;
using SlotMachineApp.Models;
using SlotMachineApp.Services;

namespace SlotMachineApp
{
    public class Program
    {
        static void Main()
        {
            var symbols = SymbolFactory.CreateSymbols();
            
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISymbol, Symbol>()
                .AddSingleton<IConsole, ConsoleWrapper>()
                .AddSingleton<ISlotMachineService, SlotMachineService>()
                .AddSingleton<ISlotMachine>(provider => new SlotMachine(new ConsoleWrapper(), new SlotMachineService(), symbols, 0, 0))
                .BuildServiceProvider();

             serviceProvider.GetService<ISlotMachine>().Start();
        }
    }

}