using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRemapper.Mapper
{
    public class DeviceDef
    {
        public string HID { get; set; }
        public int DeviceIndex { get; set; }
        public override string ToString()
        {
            return string.Format("{1} - {0}", HID, DeviceIndex);
        }

        public static DeviceDef Parse(string str)
        {
            var devdef = new DeviceDef();
            
            int devId;
            if (!int.TryParse(str.Substring(0, str.IndexOf('-')).Trim(), out devId))
            {
                throw new Exception(string.Format("Error: Could not parse device id `{0}`",
                    str.Substring(0, str.IndexOf('-')).Trim()));
            }
            devdef.DeviceIndex = devId;
            devdef.HID = str.Substring(str.IndexOf('-') + 1).Trim();
            return devdef;
        }
    }
}
