using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube
{
    public interface ICube
    {
        bool is_complete();
        ISlice get_slice(SliceIdentifier identifier);
        ICube replace_slice(SliceIdentifier identifier, ISlice slice);
    }
}
