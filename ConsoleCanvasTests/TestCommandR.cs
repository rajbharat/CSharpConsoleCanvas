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
    class TestCommandR
    {
        [TestMethod()]
        public void TestCommandR1()
        {
            Canvas canvas;
  
             Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r'));;

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdL is CmdR);
            String[] parametersC = { "20", "4" };
            String[] parametersR1 = { "16", "1", "20", "3" }; // correct parameters
            String[] parametersR2 = { "16", "1", "20", "3", "2" };
            String[] parametersR3 = { "16", "1", "20", "L" };
            String[] parametersR4 = { "16", "1", "20" };

            String[] parametersR5a = { "6", "3", "24", "3" }; // out of canvas boundary
            String[] parametersR5b = { "6", "3", "12", "7" }; // out of canvas boundary
            String[] parametersR5C = { "23", "3", "6", "4" }; // out of canvas boundary
            String[] parametersR5D = { "6", "8", "12", "4" }; // out of canvas boundary
            String[] parametersR6a = { "-6", "3", "6", "4" }; // negative coordinates
            String[] parametersR6b = { "6", "-3", "6", "4" }; // negative coordinates
            String[] parametersR6c = { "6", "3", "-6", "4" }; // negative coordinates
            String[] parametersR6d = { "6", "3", "6", "-4" }; // negative coordinates

            Assert.IsTrue(cmdL.Execute(parametersR1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersR2) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR3) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR4) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR5a) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR5b) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR5C) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR5D) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR6a) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR6b) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR6c) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR6d) == -1);

            Assert.IsTrue(cmdL.Execute(parametersR1) == 0);
        }
    }
}
