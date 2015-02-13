using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRemapper.Mapper
{
    [Serializable]
    public class ConfigNode
    {
        public ushort Key;
        public bool FlagE0;
        public bool FlagE1;
        public bool FlagUp;
        public bool IgnoreKey;
        public string DeviceHID;
        public int DeviceID;
    }
}
