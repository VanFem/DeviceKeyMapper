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
                    if (!KeyData.Value.IgnoreKey)
                    {
                        return
                            string.Format("[  {0}{6}{7} ({4}) ] at {1}  MAPPED TO  [  {2}{8}{9} ({5}) ] at {3}",
                                KeyData.Key.Key,
                                KeyData.Key.DeviceInfo,
                                KeyData.Value.Key, KeyData.Value.DeviceInfo,
                                KeyData.Key.Key < KeyInterceptor.kbdus.Count
                                    ? Enum.GetName(typeof (Keys), KeyInterceptor.kbdus[KeyData.Key.Key])
                                    : "--",
                                KeyData.Value.Key < KeyInterceptor.kbdus.Count
                                    ? Enum.GetName(typeof (Keys), KeyInterceptor.kbdus[KeyData.Value.Key])
                                    : "--",
                                KeyData.Key.FlagE0 ? "-E0" : "",
                                KeyData.Key.FlagE1 ? "-E1" : "",
                                KeyData.Value.FlagE0 ? "-E0" : "",
                                KeyData.Value.FlagE1 ? "-E1" : "");
                    }
                    return string.Format("[  {0}{3}{4} ({2}) ] at {1}  IGNORED",
                        KeyData.Key.Key,
                        KeyData.Key.DeviceInfo,
                        KeyData.Key.Key < KeyInterceptor.kbdus.Count
                            ? Enum.GetName(typeof (Keys), KeyInterceptor.kbdus[KeyData.Key.Key])
                            : "--",
                        KeyData.Key.FlagE0 ? "-E0" : "",
                        KeyData.Key.FlagE1 ? "-E1" : "");
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
                AddMapping(mapSetupDialog.KeysUnderSetup);
                SetDataForListBox();
            }
            mapSetupDialog.Dispose();
            mapSetupDialog = null;
        }

        private void AddMapping(KeyValuePair<KeyDef, KeyDef> keysUnderSetup)
        {
            if (MapperUnderSetup.MapDefinitions.Keys.Any(k => k.KeyMatches(keysUnderSetup.Key) && k.DeviceInfo.ToString() == keysUnderSetup.Key.DeviceInfo.ToString()))
            {
                if (MessageBox.Show("Mapping for that key already exists. Do you want to replace the current one?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MapperUnderSetup.MapDefinitions.Remove(
                        MapperUnderSetup.MapDefinitions.Keys.Single(
                            k =>
                                keysUnderSetup.Key.KeyMatches(k) &&
                                k.DeviceInfo.ToString() == keysUnderSetup.Key.DeviceInfo.ToString()));
                }
                else
                {
                    return;
                }
            }
            MapperUnderSetup.MapDefinitions.Add(mapSetupDialog.KeysUnderSetup.Key,
                mapSetupDialog.KeysUnderSetup.Value);
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
            if (listBox1.SelectedValue == null) 
                return;

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
