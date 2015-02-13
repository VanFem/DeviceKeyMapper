using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyRemapper.Mapper
{
    public class KeyDef
    {
        public ushort Key { get; set; }
        public bool FlagE0 { get; set; }
        public bool FlagE1 { get; set; }
        public DeviceDef DeviceInfo { get; set; }

        public bool KeyMatches(KeyDef otherKey)
        {
            return (otherKey.Key == Key && otherKey.FlagE0 == FlagE0 && otherKey.FlagE1 == FlagE1);
        }
    }
}
