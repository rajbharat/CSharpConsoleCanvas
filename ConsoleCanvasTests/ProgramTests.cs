using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;

namespace ConsoleCanvas.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void TestCommandC()
        {
            CommandFactory commandFactory = new CommandFactory();
            Command cmd = commandFactory.GetCommand('c');

            Assert.IsTrue(cmd is CmdC);
            String[] parameters1 = { "10", "5" };
            String[] parameters2 = { "10", "5", "4" };
            String[] parameters3 = { "10", "f" };
            Assert.IsTrue(cmd.Execute(parameters2) == -1);
            Assert.IsTrue(cmd.Execute(parameters3) == -1);
            Assert.IsTrue(cmd.Execute(null) == -1);
            Assert.IsTrue(cmd.Execute(parameters1) == 0);
        }
        [TestMethod()]
        public void TestCommandL()
        {
            Canvas canvas;
            CommandFactory commandFactory = new CommandFactory();
            Command cmdC = commandFactory.GetCommand('c');
            Command cmdL = commandFactory.GetCommand('l');

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdL is CmdL);
            String[] parametersC = { "20", "4" };
            String[] parametersL1 = { "1", "2", "6", "2" }; // correct parameters
            String[] parametersL2 = { "1", "2", "6", "2", "2" };
            String[] parametersL3 = { "1", "2", "6", "L" };
            String[] parametersL4 = { "1", "2", "6" };
            String[] parametersL5 = { "6", "3", "6", "4" }; // correct parameters

            Assert.IsTrue(cmdL.Execute(parametersL1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.GetCanvas();
            cmdL.SetCanvas(canvas);
            Assert.IsTrue(cmdL.Execute(parametersL2) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL3) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL4) == -1);
            Assert.IsTrue(cmdL.Execute(parametersL1) == 0);
            Assert.IsTrue(cmdL.Execute(parametersL5) == 0);
        }
        [TestMethod()]
        public void TestCommandR()
        {
            Canvas canvas;
            CommandFactory commandFactory = new CommandFactory();
            Command cmdC = commandFactory.GetCommand('c');
            Command cmdL = commandFactory.GetCommand('r');

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdL is CmdR);
            String[] parametersC = { "20", "4" };
            String[] parametersR1 = { "16", "1", "20", "3" }; // correct parameters
            String[] parametersR2 = { "16", "1", "20", "3", "2" };
            String[] parametersR3 = { "16", "1", "20", "L" };
            String[] parametersR4 = { "16", "1", "20" };

            Assert.IsTrue(cmdL.Execute(parametersR1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.GetCanvas();
            cmdL.SetCanvas(canvas);
            Assert.IsTrue(cmdL.Execute(parametersR2) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR3) == -1);
            Assert.IsTrue(cmdL.Execute(parametersR4) == -1);

            Assert.IsTrue(cmdL.Execute(parametersR1) == 0);
        }
        [TestMethod()]
        public void TestCommandB()
        {
            Canvas canvas;
            CommandFactory commandFactory = new CommandFactory();
            Command cmdC = commandFactory.GetCommand('c');
            Command cmdB = commandFactory.GetCommand('b');

            Assert.IsTrue(cmdC is CmdC);
            Assert.IsTrue(cmdB is CmdB);
            String[] parametersC = { "20", "4" };
            String[] parametersB1 = { "10", "3", "O" }; // correct parameters
            String[] parametersB2 = { "10", "3", "O", "2" };
            String[] parametersB3 = { "10", "B", "O" };
            String[] parametersB4 = { "10", "3" };

            Assert.IsTrue(cmdB.Execute(parametersB1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.GetCanvas();
            cmdB.SetCanvas(canvas);
            Assert.IsTrue(cmdB.Execute(parametersB2) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB3) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB4) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB1) == 0);
        }
        [TestMethod()]
        public void TestApp()
        {
            Canvas canvas;
            CommandFactory commandFactory = new CommandFactory();
            Command cmd = commandFactory.GetCommand('c');

            Assert.IsTrue(cmd is CmdC);

            String[] parametersC = { "20", "4" };
            String[] parametersL1 = { "1", "2", "6", "2" };
            String[] parametersL2 = { "6", "3", "6", "4" };
            String[] parametersR = { "16", "1", "20", "3" };
            String[] parametersB = { "10", "3", "o" };

            // create
            Assert.IsTrue(cmd.Execute(parametersC) == 0);
            canvas = cmd.GetCanvas();

            // line
            cmd = commandFactory.GetCommand('l');
            Assert.IsTrue(cmd is CmdL);
            cmd.SetCanvas(canvas);
            Assert.IsTrue(cmd.Execute(parametersL1) == 0);
            Assert.IsTrue(cmd.Execute(parametersL2) == 0);

            // rectangle
            cmd = commandFactory.GetCommand('r');
            Assert.IsTrue(cmd is CmdR);
            cmd.SetCanvas(canvas);
            Assert.IsTrue(cmd.Execute(parametersR) == 0);

            // bucket fill
            cmd = commandFactory.GetCommand('b');
            Assert.IsTrue(cmd is CmdB);
            cmd.SetCanvas(canvas);
            Assert.IsTrue(cmd.Execute(parametersB) == 0);
        }

    }
}