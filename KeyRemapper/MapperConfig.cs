using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRemapper.Mapper;

namespace KeyRemapper
{
    public partial class MapperConfig : Form
    {
        private class DisplaySet
        {
            public KeyValuePair<KeyDef, KeyDef> KeyData;

            public string DisplayText
            {
                get
                {
                    return string.Format("{0} at {1} -> {2} at {3}", KeyData.Key.Key, KeyData.Key.DeviceInfo,
                        KeyData.Value.Key, KeyData.Value.DeviceInfo);
                }
            }
        }

        public MapperConfig(Mapper.Mapper mapper)
        {
            InitializeComponent();
            listBox1.DataSource = mapper.MapDefinitions.Select(m=> new DisplaySet { KeyData = new KeyValuePair<KeyDef,KeyDef>(m.Key, m.Value)}).ToList();
            listBox1.DisplayMember = "DisplayText";
            //listBox1.ValueMember = "KeyData";

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
