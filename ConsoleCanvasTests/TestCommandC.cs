using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCanvasTests
{
    class TestCommandC
    {
        [TestMethod()]
        public void TestCommandC1()
        {
            CommandFactory commandFactory = new CommandFactory();
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));

            Assert.IsTrue(cmd is CmdC);
            String[] parameters1 = { "10", "5" };
            String[] parameters2 = { "10", "5", "4" };
            String[] parameters3 = { "10", "f" };
            String[] parameters4A = { "-10", "5" }; //negative
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters2) == -1);
            Assert.IsTrue(cmd.Execute(parameters3) == -1);
            Assert.IsTrue(cmd.Execute(parameters4A) == -1);
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
            Assert.IsTrue(cmd.Execute(null) == -1);
            Assert.IsTrue(cmd.Execute(parameters1) == 0);
        }
    }
}
