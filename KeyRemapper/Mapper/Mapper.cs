using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput;

namespace KeyRemapper.Mapper
{
    public class Mapper
    {
        public Dictionary<KeyDef, KeyDef> MapDefinitions { get; set; }

        public Mapper()
        {
            MapDefinitions = new Dictionary<KeyDef, KeyDef>();
        }

        private void RemapKey(ref KeyDef key)
        {
            if (MapDefinitions.ContainsKey(key))
            {
                key = MapDefinitions[key];
            }
        }
    }
}
