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
        public string DeviceHID;
        public int DeviceID;
    }
}
