using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public class Block : IBlock
    {

        IDictionary<Axis, Colour> _colours;

        private Block(IEnumerable<Tuple<Axis, Colour>> colours)
        {
            _colours = new Dictionary<Axis, Colour>();
            foreach(var colour in colours)
            {
                _colours.Add(colour.Item1, colour.Item2);
            }
        }

        public Block(Axis axis, Colour colour) 
            : this ( new List<Tuple<Axis, Colour>>()
            {
                new Tuple<Axis, Colour>(axis, colour)
            }
                )
        {

        }

        public Block(Axis axis1, Colour colour1, Axis axis2, Colour colour2, Axis axis3, Colour colour3)
            : this(new List<Tuple<Axis, Colour>>()
            {
                new Tuple<Axis, Colour>(axis1, colour1),
                new Tuple<Axis, Colour>(axis2, colour2),
                new Tuple<Axis, Colour>(axis3, colour3)

            }
                )
        {

        }

        public Colour get_colour_in_axis(Axis axis)
        {
            if (!_colours.ContainsKey(axis))
            {
                return Colour.Blank;
            }
            else
            {
                return _colours[axis];
            }
            
        }
    }
}
