using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    class Cube : ICube
    {
        public ISlice get_slice(SliceIdentifier identifier)
        {
            throw new NotImplementedException();
        }

        public bool is_complete()
        {
            throw new NotImplementedException();
        }

        public ICube replace_slice(SliceIdentifier identifier, ISlice slice)
        {
            throw new NotImplementedException();
        }
    }
}
