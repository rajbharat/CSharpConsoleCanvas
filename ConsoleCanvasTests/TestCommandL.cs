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
    class TestCommandL
    {
        [TestMethod()]
        public void TestCommandL1()
        {
            Canvas canvas;
             Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdL is CmdL);
            String[] parametersC = { "20", "4" };
            String[] parametersL1 = { "1", "2", "6", "2" }; // correct parameters
            String[] parametersL2 = { "1", "2", "6", "2", "2" };
            String[] parametersL3 = { "1", "2", "6", "L" };
            String[] parametersL4 = { "1", "2", "6" };
            String[] parametersL5 = { "6", "3", "6", "4" }; // correct parameters
            String[] parametersL6a = { "6", "3", "22", "4" }; // out of canvas boundary
            String[] parametersL6b = { "6", "3", "12", "5" }; // out of canvas boundary
            String[] parametersL6C = { "22", "3", "6", "4" }; // out of canvas boundary
            String[] parametersL6D = { "6", "5", "12", "4" }; // out of canvas boundary
            String[] parametersL7a = { "-6", "3", "6", "4" }; // negative coordinates
            String[] parametersL7b = { "6", "-3", "6", "4" }; // negative coordinates
            String[] parametersL7c = { "6", "3", "-6", "4" }; // negative coordinates
            String[] parametersL7d = { "6", "3", "6", "-4" }; // negative coordinates

            Assert.IsTrue(cmdL.Execute(parametersL1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL2) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL3) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL4) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL6a) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL6b) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL6C) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL6D) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL7a) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL7b) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL7c) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL7d) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL1) == 0);
            Assert.IsTrue(cmdL.Execute(parametersL5) == 0);
        }
    }
}
