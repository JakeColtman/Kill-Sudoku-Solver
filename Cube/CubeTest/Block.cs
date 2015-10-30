﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeTest
{
    [TestClass]
    public class BlockTest
    {
                
        [TestMethod]
        public void BlockReturnsAColourInSomeAxis()
        {
            Cube.IBlock block = new Cube.Block(Cube.Axes.x, Cube.Colour.Blue);
            bool colourFound = false;
            foreach (Cube.Axes axis in Enum.GetValues(typeof(Cube.Axes)))
            {
                colourFound = colourFound || block.get_colour_in_axis(Cube.Axes.x).GetType() == typeof(Cube.Colour);
            }
            Assert.IsTrue(colourFound);

        }

        [TestMethod]
        public void AllAxesReturnAColour()
        {
            Cube.IBlock block = new Cube.Block(Cube.Axes.x, Cube.Colour.Blue);
            bool colourFound = true;
            foreach (Cube.Axes axis in Enum.GetValues(typeof(Cube.Axes)))
            {
                colourFound = colourFound && block.get_colour_in_axis(Cube.Axes.x).GetType() == typeof(Cube.Colour);
            }
            Assert.IsTrue(colourFound);

        }

    }
}
