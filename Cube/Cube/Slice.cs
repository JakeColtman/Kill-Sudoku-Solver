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

        public Slice(IBlock[,] blocks)
        {
            _blocks = blocks;
        }

        public Slice(IBlock[] blocks) : this(format_input(blocks))
        {

        }

        public IBlock get_block_in_position(int x, int y)
        {
            if (x > 2 || y > 2) return new Block(Axes.x, Colour.Blank);
            return _blocks[x, y];
        }

        public ISlice rotate(Direction direction)
        {
            IBlock[,] new_positions = new IBlock[3, 3];

            if (direction == Direction.left)
            {
                new_positions[0, 0] = _blocks[2, 0];
                new_positions[1, 0] = _blocks[2, 1];
                new_positions[2, 0] = _blocks[2, 2];
                new_positions[0, 1] = _blocks[1, 0];
                new_positions[1, 1] = _blocks[1, 1];
                new_positions[2, 1] = _blocks[2, 1];
                new_positions[0, 2] = _blocks[0, 0];
                new_positions[1, 2] = _blocks[0, 1];
                new_positions[2, 2] = _blocks[0, 2];
            }

            else
            {
                new_positions[2, 0] = _blocks[0, 0];
                new_positions[2, 1] = _blocks[1, 0];
                new_positions[2, 2] = _blocks[2, 0];
                new_positions[1, 0] = _blocks[0, 1];
                new_positions[1, 1] = _blocks[1, 1];
                new_positions[2, 1] = _blocks[2, 1];
                new_positions[0, 0] = _blocks[0, 2];
                new_positions[0, 1] = _blocks[1, 2];
                new_positions[0, 2] = _blocks[2, 2];
            }

            return new Slice(new_positions);
        }

        static IBlock[,] format_input(IBlock[] blocks)
        {
            IBlock[,] output = new IBlock[3, 3];
            for (int ii = 0; ii < blocks.Count(); ii++)
            {
                int row = ii / 3;
                int col = ii % 3;
                Console.WriteLine(row.ToString() + "--" + col.ToString() + "--" + blocks[ii].get_colour_in_axis(Axes.x));
                output[row, col] = blocks[ii];
            }
            return output;
        }

    }
}
