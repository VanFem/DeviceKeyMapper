﻿using System;
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
        public DeviceDef DeviceInfo { get; set; }
    }
}
