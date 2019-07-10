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
    public class TestCommandC
    {
        [TestMethod()]
        public void TestCommandC_Verify_Cmd()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Assert.IsTrue(cmd is CmdC);
        }

        [TestMethod()]
        public void TestCommandC_Good()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters1 = { "10", "5" };
            Assert.IsTrue(cmd.Execute(parameters1) == 0);
        }

        [TestMethod()]
        public void TestCommandC_NullParam()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            Assert.IsTrue(cmd.Execute(null) == -1);

        }
        [TestMethod()]
        public void TestCommandC_ExtraParam()
        {
  
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters2 = { "10", "5", "4" };
            Assert.IsTrue(cmd.Execute(parameters2) == -1);
        }

        [TestMethod()]
        public void TestCommandC_Invalid_Height()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters3 = { "10", "f" };
            Assert.IsTrue(cmd.Execute(parameters3) == -1);
        }

        [TestMethod()]
        public void TestCommandC_Negative_Height()
        {

            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
        }

        [TestMethod()]
        public void TestCommandC_Negative_Width()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
        }
        [TestMethod()]
        public void TestCommandC_Max_Canvas_Size_Exceeded()
        {
            Command cmd = CommandFactory.GetCommand(CanvasConsoleHelper.GetCommand('c'));
            String[] parameters1 = { "110", "5" };
            Assert.IsTrue(cmd.Execute(parameters1) == -1);
        }
    }
}
