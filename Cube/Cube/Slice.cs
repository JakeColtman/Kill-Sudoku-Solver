using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public class Slice : ISlice
    {
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
