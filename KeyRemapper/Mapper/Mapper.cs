using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void ReadConfig(MapperConfiguration config)
        {
            MapDefinitions = new Dictionary<KeyDef, KeyDef>();
            foreach (var node in config.Configurations)
            {
                var from = new KeyDef
                {
                    DeviceInfo = new DeviceDef
                    {
                        DeviceIndex = node.From.DeviceID,
                        HID = node.From.DeviceHID
                    },
                    Key = node.From.Key
                };

                var to = new KeyDef
                {
                    DeviceInfo = new DeviceDef
                    {
                        DeviceIndex = node.To.DeviceID,
                        HID = node.To.DeviceHID
                    },
                    Key = node.To.Key
                };

                 MapDefinitions.Add(from, to);
            }
        }

        public MapperConfiguration CreateConfig()
        {
            var mc = new MapperConfiguration();
            mc.Configurations = new List<ConfigFromToNode>();
            foreach (var key in MapDefinitions.Keys)
            {
                var from = new ConfigNode()
                {
                    DeviceHID = key.DeviceInfo.HID,
                    DeviceID = key.DeviceInfo.DeviceIndex,
                    Key = key.Key
                };

                var to = new ConfigNode()
                {
                    DeviceHID = MapDefinitions[key].DeviceInfo.HID,
                    DeviceID = MapDefinitions[key].DeviceInfo.DeviceIndex,
                    Key = MapDefinitions[key].Key
                };
                mc.Configurations.Add(new ConfigFromToNode() { From = from, To = to});
            }
            return mc;
        }

        public bool Armed { get; set; }

        public Mapper()
        {
            MapDefinitions = new Dictionary<KeyDef, KeyDef>();
        }

        public KeyDef RemapKey(KeyDef key)
        {
            if (MapDefinitions.Keys.Any(k => key.Key == k.Key && key.DeviceInfo.HID == k.DeviceInfo.HID))
            {
                KeyDef keyInHash;
                if (MapDefinitions.Keys.Count(k => key.Key == k.Key && key.DeviceInfo.HID == k.DeviceInfo.HID) == 1)
                {
                    keyInHash =
                        MapDefinitions.Keys.Single(k => key.Key == k.Key && key.DeviceInfo.HID == k.DeviceInfo.HID);
                }
                else
                {
                    if (
                        MapDefinitions.Keys.Count(
                            k => key.Key == k.Key && key.DeviceInfo.ToString() == k.DeviceInfo.ToString()) == 1)
                    {
                        keyInHash =
                            MapDefinitions.Keys.Single(k => key.Key == k.Key && key.DeviceInfo.HID == k.DeviceInfo.HID);
                    }
                    else
                    {
                        return key;
                    }
                }

                return MapDefinitions[keyInHash];
            }
            return key;
        }
    }
}
