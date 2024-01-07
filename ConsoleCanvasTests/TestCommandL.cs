using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class TestCommandL
    {
        [TestMethod()]
        public void Test_CmdL_Good()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL5 = { "6", "3", "6", "4" }; // correct parameters
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL5) == 0);
        }
        [TestMethod]
        public void Test_CmdL()
        {
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            Assert.IsTrue(cmdL is CmdL);
        }
        [TestMethod()]
        public void Test_CmdL_InvalidParam()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL3 = { "1", "2", "6", "L" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL3) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_InsufficientParam()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL4 = { "1", "2", "6" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL4) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_ExtraParam()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL2 = { "1", "2", "6", "2", "2" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL2) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_LineBeforeCanvas()
        {
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL1 = { "1", "2", "6", "2" }; // correct parameters
            Assert.IsTrue(cmdL.Execute(parametersL1) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point1_X_OutsideCanvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL6a = { "6", "3", "22", "4" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL6a) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point1_Y_OutsideCanvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL6b = { "6", "3", "12", "5" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL6b) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point2_X_OutsideCanvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL6C = { "22", "3", "6", "4" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL6C) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point2_Y_OutsideCanvas()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL6D = { "6", "5", "12", "4" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL6D) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point1_NegX()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL7a = { "-6", "3", "6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL7a) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point1_NegY()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL7b = { "6", "-3", "6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL7b) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point2_NegX()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL7c = { "6", "3", "-6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL7c) == -1);
        }
        [TestMethod()]
        public void Test_CmdL_Point2_NegY()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdL = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            String[] parametersC = { "20", "4" };
            String[] parametersL7d = { "6", "3", "6", "-4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdL.BaseCanvas = canvas;
            Assert.IsTrue(cmdL.Execute(parametersL7d) == -1);
        }
    }
}
