using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public class Block : IBlock
    {

        IDictionary<Axes, Colour> _colours;

        private Block(IEnumerable<Tuple<Axes, Colour>> colours)
        {
            _colours = new Dictionary<Axes, Colour>();
            foreach(var colour in colours)
            {
                _colours.Add(colour.Item1, colour.Item2);
            }
        }

        public Block(Axes axis, Colour colour) 
            : this ( new List<Tuple<Axes, Colour>>()
            {
                new Tuple<Axes, Colour>(axis, colour)
            }
                )
        {

        }

        public Block(Axes axis1, Colour colour1, Axes axis2, Colour colour2, Axes axis3, Colour colour3)
            : this(new List<Tuple<Axes, Colour>>()
            {
                new Tuple<Axes, Colour>(axis1, colour1),
                new Tuple<Axes, Colour>(axis2, colour2),
                new Tuple<Axes, Colour>(axis3, colour3)

            }
                )
        {

        }

        public Colour get_colour_in_axis(Axes axis)
        {
            if (!_colours.ContainsKey(axis))
            {
                return Colour.Blank;
            }
            else
            {
                return Colour.Green;
            }
            
        }
    }
}
