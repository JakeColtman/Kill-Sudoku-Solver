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
        public void RotateLeft()
        {
            _slice.rotate(Cube.Direction.left);            
        }
    }
}
