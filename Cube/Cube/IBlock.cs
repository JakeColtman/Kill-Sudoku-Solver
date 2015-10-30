using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public interface IBlock
    {
        Colour get_colour_in_axis(Axis axis);
    }
}
