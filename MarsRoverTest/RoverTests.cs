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

            var output =  controller.SendCommand(@"
55
12N
LMLMLMLMM
33E
MMRMMRMRRM
");
            Assert.IsTrue(output.Trim() == @"
13N
51E
".Trim());
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
            Assert.IsTrue(output.Trim() == @"
23W
".Trim());
        }
    }
}
