using ConsoleCanvas.Factory;
using ConsoleCanvas.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            String[] parameters4A = { "-10", "5" }; //negative
            String[] parameters4B = { "10", "-5" }; //negative
            Assert.IsTrue(cmd.Execute(parameters2) == -1);
            Assert.IsTrue(cmd.Execute(parameters3) == -1);
            Assert.IsTrue(cmd.Execute(parameters4A) == -1);
            Assert.IsTrue(cmd.Execute(parameters4B) == -1);
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
            canvas = cmdC.GetCanvas();
            cmdL.SetCanvas(canvas);
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
            canvas = cmdC.GetCanvas();
            cmdL.SetCanvas(canvas);
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

            String[] parametersB5a = { "23", "3", "0" }; // out of canvas boundary
            String[] parametersB5b = { "6", "8", "8" }; // out of canvas boundary
            String[] parametersB6a = { "-6", "3", "6" }; // negative coordinates
            String[] parametersB6b = { "6", "-3", "6" }; // negative coordinates


            Assert.IsTrue(cmdB.Execute(parametersB1) == -1);
            cmdC.Execute(parametersC);
            canvas = cmdC.GetCanvas();
            cmdB.SetCanvas(canvas);
            Assert.IsTrue(cmdB.Execute(parametersB2) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB3) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB4) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB5a) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB5b) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB6a) == -1);
            Assert.IsTrue(cmdB.Execute(parametersB6b) == -1);


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