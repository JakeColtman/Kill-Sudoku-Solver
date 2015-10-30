using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cube;

namespace CubeTest
{
    [TestClass]
    public class MinimalTestSlice
    {

        Cube.ISlice _slice;


        [TestInitialize]
        public void setup()
        {
            IBlock[] _basicBlocks = new IBlock[9]
            {
                new Block(Axes.x, Colour.Blue),
                new Block(Axes.x, Colour.Red),
                new Block(Axes.x, Colour.White),
                new Block(Axes.x, Colour.Green),
                new Block(Axes.x, Colour.Orange),
                new Block(Axes.x, Colour.Blank),
                new Block(Axes.x, Colour.Yellow),
                new Block(Axes.x, Colour.Blank),
                new Block(Axes.x, Colour.Yellow),
            };
            _slice = new Cube.Slice(_basicBlocks);
        }

        [TestMethod]
        public void RotateLeftDoestThrowError()
        {
            _slice.rotate(Cube.Direction.left);            
        }

        [TestMethod]
        public void RotationChangesTheSlice()
        {
            Assert.AreNotEqual(_slice,_slice.rotate(Cube.Direction.left));
        }

        [TestMethod]
        public void RotatedObjectContainsBlocks()
        {
            Assert.IsInstanceOfType(_slice.rotate(Cube.Direction.left).get_block_in_position(1, 1), typeof(Cube.IBlock));
        }

    }
}
