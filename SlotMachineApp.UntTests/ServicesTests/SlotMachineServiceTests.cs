using NUnit.Framework;
using SlotMachineApp.Contracts;
using SlotMachineApp.Factories;
using SlotMachineApp.Models;
using SlotMachineApp.Services;
using System;
using System.Collections.Generic;

namespace SlotMachineApp.UntTests.ServicesTests
{
    public class SlotMachineServiceTests
    {
        [Test]
        public void CalculateWin_WhenValidParameters_ShouldReturnsCorrectWinAmount()
        {
            // Arrange
            var symbols = SymbolFactory.CreateSymbols();
            var stake = 10;
            var service = new SlotMachineService();
            var table = new char[4, 3]
            {
                { 'B', 'A', 'A' },
                { 'A', 'A', 'A' },
                { '*', 'A', 'A' },
                { 'A', 'B', '*' },
            };

            // Act
            var win = service.CalculateWin(table, symbols, stake);

            // Assert
            Assert.AreEqual(20.0, win);
        }

        [Test]
        public void GetCoefficient_WhenValidParametersArePased_ShouldReturnCorrectResults()
        {
            // Arrange
            var symbols = SymbolFactory.CreateSymbols();
            var service = new SlotMachineService();

            // Act
            var coefficientA = service.GetCoefficient('A', symbols);
            var coefficientB = service.GetCoefficient('B', symbols);
            var coefficientP = service.GetCoefficient('P', symbols);
            var coefficientWildcard = service.GetCoefficient('*', symbols);

            // Assert
            Assert.AreEqual(0.4, coefficientA);
            Assert.AreEqual(0.6, coefficientB);
            Assert.AreEqual(0.8, coefficientP);
            Assert.AreEqual(0, coefficientWildcard);
        }

        [Test]
        public void CalculateTotalBalance_WhenValidParametersArePased_ShouldReturnsCorrectTotalBalance()
        {
            // Arrange
            var service = new SlotMachineService();

            // Act
            var totalBalance = service.CalculateTotalBalance(100, 10, 1);

            // Assert
            Assert.AreEqual(109, totalBalance);
        }

        [Test]
        public void CalculateTotalBalance_WhenStakeIsGreaterThanBalance_ShouldReturnZero()
        {
            // Arrange
            var service = new SlotMachineService();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateTotalBalance(100, 10, 1000));
            Assert.That(ex.Message, Is.EqualTo("Stake amount cannot be greater than your deposit balance!"));
        }
    }
}
