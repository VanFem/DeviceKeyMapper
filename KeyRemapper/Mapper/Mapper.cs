﻿using System;
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
                if (node.From.IgnoreKey)
                {
                    Debug.WriteLine("Error: Invalid configuration FROM");
                    continue;
                }

                var from = new KeyDef
                {
                    DeviceInfo = new DeviceDef
                    {
                        DeviceIndex = node.From.DeviceID,
                        HID = node.From.DeviceHID
                    },
                    Key = node.From.Key,
                    FlagE0 = node.From.FlagE0,
                    FlagE1 = node.From.FlagE1,
                    IgnoreKey = node.From.IgnoreKey
                };

                var to = new KeyDef
                {
                    DeviceInfo = new DeviceDef
                    {
                        DeviceIndex = node.To.DeviceID,
                        HID = node.To.DeviceHID
                    },
                    Key = node.To.Key,
                    FlagE0 = node.To.FlagE0,
                    FlagE1 = node.To.FlagE1,
                    IgnoreKey = node.To.IgnoreKey
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
                if (key.IgnoreKey)
                {
                    Debug.WriteLine("Error: Invalid configuration FROM");
                    continue;
                }

                var from = new ConfigNode()
                {
                    DeviceHID = key.DeviceInfo.HID,
                    DeviceID = key.DeviceInfo.DeviceIndex,
                    Key = key.Key,
                    FlagE0 = key.FlagE0,
                    FlagE1 = key.FlagE1,
                    IgnoreKey = key.IgnoreKey
                };

                var to = new ConfigNode()
                {
                    DeviceHID = MapDefinitions[key].DeviceInfo.HID,
                    DeviceID = MapDefinitions[key].DeviceInfo.DeviceIndex,
                    Key = MapDefinitions[key].Key,
                    FlagE0 = MapDefinitions[key].FlagE0,
                    FlagE1 = MapDefinitions[key].FlagE1,
                    IgnoreKey = MapDefinitions[key].IgnoreKey
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
            if (!MapDefinitions.Keys.Any(k => key.DeviceInfo.HID == k.DeviceInfo.HID && k.KeyMatches(key))) return key;
            
            KeyDef keyInHash;
            if (MapDefinitions.Keys.Count(k => key.DeviceInfo.HID == k.DeviceInfo.HID && k.KeyMatches(key)) == 1)
            {
                keyInHash =
                    MapDefinitions.Keys.Single(k => key.DeviceInfo.HID == k.DeviceInfo.HID && k.KeyMatches(key));
            }
            else
            {
                if (
                    MapDefinitions.Keys.Count(k => key.DeviceInfo.ToString() == k.DeviceInfo.ToString() && k.KeyMatches(key)) == 1)
                {
                    keyInHash =
                        MapDefinitions.Keys.Single(k => key.DeviceInfo.HID == k.DeviceInfo.HID && k.KeyMatches(key));
                }
                else
                {
                    return key;
                }
            }

            return MapDefinitions[keyInHash];
        }
    }
}
