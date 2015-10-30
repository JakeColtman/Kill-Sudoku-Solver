using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public class Slice : ISlice
    {

        IBlock[,] _blocks;

        public Slice(IBlock[] blocks)
        {
            for(int ii = 0; ii < blocks.Count(); ii++)
            {
                int row = ii / 3;
                int col = ii % 3;
                _blocks[row, col] = blocks[ii];
            }
        }

        public IBlock get_block_in_position(int x, int y)
        {
            return new Block(Axes.x, Colour.Blue);
        }

        public ISlice rotate(Direction direction)
        {
            return new Slice();
        }
    }
}
