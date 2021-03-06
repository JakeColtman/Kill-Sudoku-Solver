﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cube;

namespace CubeTest
{
    [TestClass]
    public class SliceTest
    {

        IBlock[] _basicBlocks;

        [TestInitialize]
        public void setup()
        {
            _basicBlocks = new IBlock[9]
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
        }


        [TestMethod]
        public void SliceStoresBlocksInTheRightPlaces()
        {
            ISlice _slice = new Slice(_basicBlocks);
            Assert.AreEqual(_slice.get_block_in_position(0, 0).get_colour_in_axis(Axis.x), Colour.Blue);
            Assert.AreEqual(_slice.get_block_in_position(0, 1).get_colour_in_axis(Axis.x), Colour.Red);
            Assert.AreEqual(_slice.get_block_in_position(0, 2).get_colour_in_axis(Axis.x), Colour.White);
            Assert.AreEqual(_slice.get_block_in_position(1, 0).get_colour_in_axis(Axis.x), Colour.Green);
            Assert.AreEqual(_slice.get_block_in_position(1, 1).get_colour_in_axis(Axis.x), Colour.Orange);
            
        }

        [TestMethod]
        public void RotatingAndRotatingBackBringsBackToStartPoint()
        {
            ISlice _slice = new Slice(_basicBlocks);
            ISlice newSlice =_slice.rotate(Direction.left).rotate(Direction.right);
            Assert.AreEqual(newSlice.get_block_in_position(0, 0).get_colour_in_axis(Axis.x), Colour.Blue);
            Assert.AreEqual(newSlice.get_block_in_position(0, 1).get_colour_in_axis(Axis.x), Colour.Red);
            Assert.AreEqual(newSlice.get_block_in_position(0, 2).get_colour_in_axis(Axis.x), Colour.White);
            Assert.AreEqual(newSlice.get_block_in_position(1, 0).get_colour_in_axis(Axis.x), Colour.Green);
            Assert.AreEqual(newSlice.get_block_in_position(1, 1).get_colour_in_axis(Axis.x), Colour.Orange);

        }


    }
}
