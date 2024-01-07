using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class TestApp
    {

        [TestMethod()]
        public void DrawAllShapes()
        {
            Canvas canvas;
            CanvasConsoleHelper.GetCommand('c');

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));

            Assert.IsTrue(cmd is CmdC);

            String[] parametersC = { "20", "4" };
            String[] parametersL1 = { "1", "2", "6", "2" };
            String[] parametersL2 = { "6", "3", "6", "4" };
            String[] parametersR = { "16", "1", "20", "3" };
            String[] parametersB = { "10", "3", "0" };

            // create
            Assert.IsTrue(cmd.Execute(parametersC) == 0);
            canvas = cmd.BaseCanvas;

            // line
            cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('L'));
            Assert.IsTrue(cmd is CmdL);
            cmd.BaseCanvas = canvas;
            Assert.IsTrue(cmd.Execute(parametersL1) == 0);
            Assert.IsTrue(cmd.Execute(parametersL2) == 0);

            // rectangle
            cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('R'));
            Assert.IsTrue(cmd is CmdR);
            cmd.BaseCanvas = canvas;
            Assert.IsTrue(cmd.Execute(parametersR) == 0);

            // bucket fill
            cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('B'));
            Assert.IsTrue(cmd is CmdB);
            cmd.BaseCanvas = canvas;
            Assert.IsTrue(cmd.Execute(parametersB) == 0);
        }

    }
}