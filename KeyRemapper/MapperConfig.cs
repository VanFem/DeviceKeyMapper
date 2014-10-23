using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRemapper.Annotations;
using KeyRemapper.Mapper;

namespace KeyRemapper
{
    public partial class MapperConfig : Form
    {

        public Mapper.Mapper MapperUnderSetup { get; set; }

        private MapSetup mapSetupDialog;
        
        private class DisplaySet
        {
            public KeyValuePair<KeyDef, KeyDef> KeyData { get; set; }

            [UsedImplicitly]
            public string DisplayText
            {
                get
                {
                    return string.Format("[  {0}  ] at {1}  -->  [  {2}  ] at {3}", KeyData.Key.Key, KeyData.Key.DeviceInfo,
                        KeyData.Value.Key, KeyData.Value.DeviceInfo);
                }
            }
        }

        public MapperConfig(Mapper.Mapper mapper)
        {
            InitializeComponent();
            MapperUnderSetup = mapper;
            SetDataForListBox();
        }

        private void SetDataForListBox()
        {
            listBox1.DataSource = MapperUnderSetup.MapDefinitions.Select(m=> new DisplaySet { KeyData = new KeyValuePair<KeyDef,KeyDef>(m.Key, m.Value)}).ToList();
            listBox1.DisplayMember = "DisplayText";
            listBox1.ValueMember = "KeyData";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapSetupDialog = new MapSetup();
            mapSetupDialog.ShowDialog();

            if (mapSetupDialog.DialogResult == DialogResult.OK)
            {
                if (MapperUnderSetup.MapDefinitions.Keys.Any(k => k.Key == mapSetupDialog.KeysUnderSetup.Key.Key && k.DeviceInfo.ToString() == mapSetupDialog.KeysUnderSetup.Key.DeviceInfo.ToString()))
                {
                    if (MessageBox.Show("Mapping for that key already exists. Do you want to replace the current one?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        MapperUnderSetup.MapDefinitions.Remove(
                            MapperUnderSetup.MapDefinitions.Keys.Single(
                                k =>
                                    k.Key == mapSetupDialog.KeysUnderSetup.Key.Key &&
                                    k.DeviceInfo.ToString() == mapSetupDialog.KeysUnderSetup.Key.DeviceInfo.ToString()));

                    }
                    else
                    {
                        mapSetupDialog.Dispose();
                        mapSetupDialog = null;
                        return;
                    }
                }
                MapperUnderSetup.MapDefinitions.Add(mapSetupDialog.KeysUnderSetup.Key,
                    mapSetupDialog.KeysUnderSetup.Value);
                SetDataForListBox();
            }
            mapSetupDialog.Dispose();
            mapSetupDialog = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected mapping?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                MapperUnderSetup.MapDefinitions.Remove(((KeyValuePair<KeyDef, KeyDef>)listBox1.SelectedValue).Key);
                SetDataForListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mapSetupDialog = new MapSetup( (KeyValuePair<KeyDef, KeyDef>)listBox1.SelectedValue );
            mapSetupDialog.ShowDialog();

            if (mapSetupDialog.DialogResult == DialogResult.OK)
            {
                MapperUnderSetup.MapDefinitions.Remove(((KeyValuePair<KeyDef, KeyDef>)listBox1.SelectedValue).Key);
                MapperUnderSetup.MapDefinitions.Add(mapSetupDialog.KeysUnderSetup.Key,
                    mapSetupDialog.KeysUnderSetup.Value);
                SetDataForListBox();
            }
            else
            {
                mapSetupDialog.Dispose();
                mapSetupDialog = null;
            }
        }
    }
}
