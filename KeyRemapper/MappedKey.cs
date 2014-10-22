using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput;

namespace KeyRemapper
{
    public class MappedKey
    {
        public InputDevice.DeviceInfo SourceDevice { get; set; }
        public InputDevice.DeviceInfo DestinationDevice { get; set; }
        public ushort SourceKey;
        public ushort DestinationKey;
    }
}
