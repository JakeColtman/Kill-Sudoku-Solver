using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeTest
{
    [TestClass]
    public class MinimalTestSlice
    {

        Cube.ISlice _slice;

        [TestInitialize]
        public void setup()
        {
            _slice = new Cube.Slice(new Cube.IBlock[0]);
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
