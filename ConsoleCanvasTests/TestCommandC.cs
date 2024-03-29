﻿using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class Test_CmdC
    {
        [TestMethod()]
        public void Test_CmdC_Verify_Cmd()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Assert.IsTrue(cmd is CmdC);
        }

        [TestMethod()]
        public void Test_CmdC_Good()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters1 = { "10", "5" };
            Assert.IsTrue(cmd.Execute(parameters1) == 0);
        }

        [TestMethod()]
        public void Test_CmdC_NullParam()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Assert.IsTrue(cmd.Execute(null) == -1);

        }
        [TestMethod()]
        public void Test_CmdC_ExtraParam()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters2 = { "10", "5", "4" };
            Assert.IsTrue(cmd.Execute(parameters2) == -1);
        }

        [TestMethod()]
        public void Test_CmdC_Invalid_Height()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters3 = { "10", "f" };
            Assert.IsTrue(cmd.Execute(parameters3) == -1);
        }

        [TestMethod()]
        public void Test_CmdC_Negative_Height()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
        }

        [TestMethod()]
        public void Test_CmdC_Negative_Width()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
        }
        [TestMethod()]
        public void Test_CmdC_Max_Canvas_Size_Exceeded()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters1 = { "110", "5" };
            Assert.IsTrue(cmd.Execute(parameters1) == -1);
        }
    }
}
