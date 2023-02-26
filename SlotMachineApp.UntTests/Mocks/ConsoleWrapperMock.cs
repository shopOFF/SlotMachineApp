using SlotMachineApp.Contracts;
using System;
using System.Collections.Generic;

namespace SlotMachineApp.UntTests.Mocks
{
    public class ConsoleWrapperMock : IConsole
    {
        public List<String> LinesToRead = new List<String>();
        public List<String> LinesToWrite = new List<String>();

        public void Write(string message)
        {
        }

        public void WriteLine(string message)
        {
            LinesToWrite.Add(message);
        }

        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
}
