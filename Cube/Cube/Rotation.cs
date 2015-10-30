using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Rotation
    {

        Axis _axis;
        Direction _direction;

        public Rotation(Axis axis, Direction direction)
        {
            _axis = axis;
            _direction = direction;
        }

        public Axis get_axis()
        {
            return _axis;
        }

        public Direction get_direction()
        {
            return _direction;
        }

       
    }
}
