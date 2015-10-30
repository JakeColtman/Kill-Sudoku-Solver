using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public class Slice : ISlice
    {
        
        public ISlice rotate(Direction direction)
        {
            return new Slice();
        }
    }
}
