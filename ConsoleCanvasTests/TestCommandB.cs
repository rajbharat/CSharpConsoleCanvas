using ConsoleCanvas;
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
    class TestCommandB
    {
        [TestMethod()]
        public void TestCommandB1()
        {
            Canvas canvas;
            CommandFactory commandFactory = new CommandFactory();
             Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdB is CmdB);
            String[] parametersC = { "20", "4" };
            String[] parametersB1 = { "10", "3", "O" }; // correct parameters
            String[] parametersB2 = { "10", "3", "O", "2" };
            String[] parametersB3 = { "10", "B", "O" };
            String[] parametersB4 = { "10", "3" };

            String[] parametersB5a = { "23", "3", "0" }; // out of canvas boundary
            String[] parametersB5b = { "6", "8", "8" }; // out of canvas boundary
            String[] parametersB6a = { "-6", "3", "6" }; // negative coordinates
            String[] parametersB6b = { "6", "-3", "6" }; // negative coordinates


            Assert.IsTrue(cmdB.Execute(parametersB1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB2) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB3) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB4) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB5a) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB5b) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB6a) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB6b) == -1);


            Assert.IsTrue(cmdB.Execute(parametersB1) == 0);
        }
    }
}
