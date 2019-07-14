using ConsoleCanvas;
using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class TestCommandB
    {
        [TestMethod()]
        public void Test_CmdB()
        {
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            Assert.IsTrue(cmdB is CmdB);
        }

        [TestMethod()]
        public void Test_CmdB_Fill_Before_Canvas()
        {
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdB is CmdB);
            String[] parametersB1 = { "10", "3", "O" }; // correct parameters
            String[] parametersC = { "20", "4" };
            Assert.IsTrue(cmdB.Execute(parametersB1) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Invalid_Height()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB3 = { "10", "B", "O" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB3) == -1);
        }

        [TestMethod()]
        public void Test_CmdB_ExtraParam()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB2 = { "10", "3", "O", "2" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB2) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_NoColorParam()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB4 = { "10", "3" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB4) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Width_Outside_Canvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB5a = { "23", "3", "0" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB5a) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Height_Outside_Canvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB5b = { "6", "8", "8" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB5b) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Negative_Width()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB6a = { "-6", "3", "6" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB6a) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Negative_Height()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB6b = { "6", "-3", "6" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB6b) == -1);
        }

        [TestMethod()]
        public void Test_CmdB_Negative_Color()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB2 = { "10", "3", "-1"};
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB2) == -1);
        }
        [TestMethod()]
        public void Test_CmdB_Ok()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdB = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            String[] parametersC = { "20", "4" };
            String[] parametersB1 = { "10", "3", "0" }; // correct parameters
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdB.BaseCanvas = canvas;
            Assert.IsTrue(cmdB.Execute(parametersB1) == 0);
        }

    }
}
