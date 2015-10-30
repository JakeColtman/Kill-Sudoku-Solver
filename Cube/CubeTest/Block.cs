using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeTest
{
    [TestClass]
    public class BlockTest
    {
                
        [TestMethod]
        public void BlockReturnsAColourInSomeAxis()
        {
            Cube.IBlock block = new Cube.Block();
            bool colourFound = false;
            foreach (Cube.Axes axis in Enum.GetValues(typeof(Cube.Axes)))
            {
                colourFound = colourFound || block.GetType() == typeof(Cube.Colour);
            }
            Assert.IsTrue(colourFound);

        }
    }
}
