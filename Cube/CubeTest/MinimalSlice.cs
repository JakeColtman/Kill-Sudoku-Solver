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
                new Block(Axis.x, Colour.Blue),
                new Block(Axis.x, Colour.Red),
                new Block(Axis.x, Colour.White),
                new Block(Axis.x, Colour.Green),
                new Block(Axis.x, Colour.Orange),
                new Block(Axis.x, Colour.Blank),
                new Block(Axis.x, Colour.Yellow),
                new Block(Axis.x, Colour.Blank),
                new Block(Axis.x, Colour.Yellow),
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
