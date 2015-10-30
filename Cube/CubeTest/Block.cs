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
            Cube.IBlock block = new Cube.Block(Cube.Axis.x, Cube.Colour.Blue);
            bool colourFound = false;
            foreach (Cube.Axis axis in Enum.GetValues(typeof(Cube.Axis)))
            {
                colourFound = colourFound || block.get_colour_in_axis(Cube.Axis.x).GetType() == typeof(Cube.Colour);
            }
            Assert.IsTrue(colourFound);

        }

        [TestMethod]
        public void AllAxesReturnAColour()
        {
            Cube.IBlock block = new Cube.Block(Cube.Axis.x, Cube.Colour.Blue);
            bool colourFound = true;
            foreach (Cube.Axis axis in Enum.GetValues(typeof(Cube.Axis)))
            {
                colourFound = colourFound && block.get_colour_in_axis(Cube.Axis.x).GetType() == typeof(Cube.Colour);
            }
            Assert.IsTrue(colourFound);

        }

        [TestMethod]
        public void BlockReturnsDefaultColourIfAxisNotSet()
        {
            Cube.IBlock block = new Cube.Block(Cube.Axis.x, Cube.Colour.Blue);
            
            Assert.AreEqual(block.get_colour_in_axis(Cube.Axis.y), Cube.Colour.Blank);
            Assert.AreEqual(block.get_colour_in_axis(Cube.Axis.z), Cube.Colour.Blank);

        }

        [TestMethod]
        public void BlockReturnsColourOfAxisItsSetTo()
        {
            Cube.IBlock block = new Cube.Block(Cube.Axis.x, Cube.Colour.Blue);

            Assert.AreEqual(block.get_colour_in_axis(Cube.Axis.x), Cube.Colour.Blue);            

        }

    }
}
