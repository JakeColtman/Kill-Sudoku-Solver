using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubeTest
{
    [TestClass]
    public class TestSlice
    {

        Cube.ISlice _slice;

        [TestInitialize]
        public void setup()
        {
            _slice = new Cube.Slice();
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

    }
}
