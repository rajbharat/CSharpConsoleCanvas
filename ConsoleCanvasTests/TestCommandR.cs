using ConsoleCanvas;
using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class Test_CmdR
    {
        [TestMethod()]
        public void Test_CmdR_Good()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR1 = { "16", "1", "20", "3" }; // correct parameters
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR1) == 0);
        }
        [TestMethod()]
        public void Test_CmdR_VerifyCmd()
        {
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); 
            Assert.IsTrue(cmdR is CmdR);           
        }
        [TestMethod()]
        public void Test_CmdR_ExtraParam()
        {
            Canvas canvas;

            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR2 = { "16", "1", "20", "3", "2" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR2) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Invalid_Param()
        {
            Canvas canvas;

            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR3 = { "16", "1", "20", "L" };
 
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR3) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Insufficient_Param()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR4 = { "16", "1", "20" };
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR4) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Rectangle_Before_Canvas()
        {
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR1 = { "16", "1", "20", "3" }; // correct parameters
            Assert.IsTrue(cmdR.Execute(parametersR1) == -1);
        }

        [TestMethod()]
        public void Test_CmdR_Point1_Outside_Boundary_X()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR5a = { "6", "3", "24", "3" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR5a) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point1_Outside_Boundary_Y()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR5b = { "6", "3", "12", "7" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR5b) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point2_Outside_Boundary_X()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR5C = { "23", "3", "6", "4" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR5C) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point2_Outside_Boundary_Y()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR5D = { "6", "8", "12", "4" }; // out of canvas boundary
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR5D) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point1_NegX()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR6a = { "-6", "3", "6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR6a) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point1_NegY()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR6b = { "6", "-3", "6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR6b) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point2_NegX()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR6c = { "6", "3", "-6", "4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR6c) == -1);
        }
        [TestMethod()]
        public void Test_CmdR_Point2_NegY()
        {
            Canvas canvas;
            Command cmdC = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Command cmdR = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('r')); ;
            String[] parametersC = { "20", "4" };
            String[] parametersR6d = { "6", "3", "6", "-4" }; // negative coordinates
            cmdC.Execute(parametersC);
            canvas = cmdC.BaseCanvas;
            cmdR.BaseCanvas = canvas;
            Assert.IsTrue(cmdR.Execute(parametersR6d) == -1);
        }
    }
}
