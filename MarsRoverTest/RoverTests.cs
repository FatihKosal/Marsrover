using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTest
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            RoverController controller = new RoverController();

            var output = controller.SendCommand(@"
55
12N
LMLMLMLMM
33E
MMRMMRMRRM
");

            Assert.IsTrue(output.Replace("\n", "").Replace("\r", "") == @"
13N
51E
".Replace("\n", "").Replace("\r", ""));
        }

        [TestMethod]
        public void TestMethod2()
        {
            RoverController controller = new RoverController();

            var output = controller.SendCommand(@"
66
32E
LMLM
");
            Assert.IsTrue(output.Replace("\n", "").Replace("\r", "") == @"
23W
".Replace("\n", "").Replace("\r", ""));
        }
    }
}
