using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRemapper.Mapper;
using RawInput;

namespace KeyRemapper
{

    public enum KeyMapOptions
    {
        KeyUpDownToDifferent = 1,
        KeyUp = 2,
        KeyDown = 3,
        KeyUpExclusive = 4,
        KeyDownExclusive = 5,
        KeyUpDownToOne = 6
    }

    public partial class MapSetup : Form
    {
        private KeyInterceptor kInterceptor = new KeyInterceptor();
        private KeyDetect kDetect;
     
        private List<DeviceDef> devicesList;

        public KeyValuePair<KeyDef, KeyDef> KeysUnderSetup;
        public KeyMapOptions MappingOptions;

        public MapSetup()
        {
            InitializeComponent();
            KeysUnderSetup = new KeyValuePair<KeyDef, KeyDef>(new KeyDef(), new KeyDef());
            SetUpComboBoxes();
        }

        public MapSetup(KeyValuePair<KeyDef, KeyDef> initialKeys)
        {
            InitializeComponent();

            KeysUnderSetup = initialKeys;

            SetUpComboBoxes();

            RefreshLabelsAndCheckboxes();

            if (!cmbDevice1.Items.Contains(initialKeys.Key.DeviceInfo.ToString()) || !cmbDevice2.Items.Contains(initialKeys.Value.DeviceInfo.ToString()))
            {
                MessageBox.Show("This map does not correspond to any active device.");
                return;
            }

            cmbDevice1.SelectedItem = initialKeys.Key.DeviceInfo.ToString();
            cmbDevice2.SelectedItem = initialKeys.Value.DeviceInfo.ToString();
        }

        private void RefreshLabelsAndCheckboxes()
        {
            RefreshLabels();
            RefreshCheckboxesAndMaps();
        }

        private void RefreshLabelsAndCheckboxesFrom()
        {
            RefreshLabelFrom();
            RefreshCheckboxesAndMaps();
        }

        private void RefreshLabelsAndCheckboxesTo()
        {
            RefreshLabelTo();
            RefreshCheckboxesAndMaps();
        }

        private void RefreshLabels()
        {
            RefreshLabelFrom();
            RefreshLabelTo();
        }

        private void RefreshLabelTo()
        {
            if (KeysUnderSetup.Value.IgnoreKey)
            {
                lblKey2.Text = "[ Nothing ]";
            }
            else
            {
                lblKey2.Text = string.Format("{0} ({1})", KeysUnderSetup.Value.Key,
                    (KeysUnderSetup.Value.Key < KeyInterceptor.kbdus.Count
                        ? Enum.GetName(typeof(Keys), KeyInterceptor.kbdus[KeysUnderSetup.Value.Key])
                        : ""));
            }
        }

        private void RefreshLabelFrom()
        {
            lblKey1.Text = string.Format("{0} ({1})", KeysUnderSetup.Key.Key,
                (KeysUnderSetup.Key.Key < KeyInterceptor.kbdus.Count
                    ? Enum.GetName(typeof(Keys), KeyInterceptor.kbdus[KeysUnderSetup.Key.Key])
                    : ""));
        }

        private void RefreshCheckboxesAndMaps()
        {
            chkE0FlagFrom.Checked = KeysUnderSetup.Key.FlagE0;
            chkE1FlagFrom.Checked = KeysUnderSetup.Key.FlagE1;
            chkE0FlagTo.Checked = KeysUnderSetup.Value.FlagE0;
            chkE1FlagTo.Checked = KeysUnderSetup.Value.FlagE1;
            numSignalCodeFrom.Value = KeysUnderSetup.Key.Key;
            numSignalCodeTo.Value = KeysUnderSetup.Value.Key;
            chkIgnore.Checked = KeysUnderSetup.Value.IgnoreKey;
        }

        private void SetUpComboBoxes()
        {
            SetUpDeviceComboBoxes();
        }

        private void SetUpDeviceComboBoxes()
        {
            devicesList = kInterceptor.GetKeyboardDevices();
            SetUpDeviceComboBox(cmbDevice1, devicesList);
            SetUpDeviceComboBox(cmbDevice2, devicesList);
        }

        private void SetUpDeviceComboBox(ComboBox cmb)
        {
            devicesList = kInterceptor.GetKeyboardDevices();
            SetUpDeviceComboBox(cmb, devicesList);
        }

        private void SetUpDeviceComboBox(ComboBox cmb, List<DeviceDef> devicesList)
        {
            cmb.Items.Clear();
            cmb.Items.AddRange(devicesList.Select(d => d.ToString()).ToArray());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbDevice1.SelectedItem == null || cmbDevice2.SelectedItem == null)
            {
                MessageBox.Show("You need to fill all the fields to set up a map.");
                return;
            }

            try
            {
                KeysUnderSetup.Key.DeviceInfo = DeviceDef.Parse(cmbDevice1.SelectedItem.ToString());
                KeysUnderSetup.Value.DeviceInfo = DeviceDef.Parse(cmbDevice2.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error parsing map definition: {0}", ex.Message));
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            SetUpDeviceComboBox(cmbDevice1);
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            SetUpDeviceComboBox(cmbDevice2);
        }

        private void btnDetectDevice1_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            setDeviceFor(cmbDevice1, key);
        }

        private KeyDef AskForKey()
        {
            if (kDetect != null) return null;
            kDetect = new KeyDetect();
            kDetect.ShowDialog();

            if (kDetect.DialogResult == DialogResult.OK)
            {
                var key = kDetect.ReceivedKey;
                kDetect.Dispose();
                kDetect = null;
                return key;
            }
            kDetect.Dispose();
            kDetect = null;
            return null;
        }

        private void setDeviceFor(ComboBox cmb, KeyDef key)
        {
            if (key == null) 
                return;
            if (cmb.Items.Contains(key.DeviceInfo.ToString()))
            {
                cmb.SelectedItem = key.DeviceInfo.ToString();
            }
            else
            {
                MessageBox.Show("The device could not be detected.");
            }
        }

        private void btnDetectBoth1_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            setDeviceFor(cmbDevice1, key);
            key.MapKeyInto(KeysUnderSetup.Key);
            RefreshLabelsAndCheckboxesFrom();
        }

        private void btnDetectDevice2_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            setDeviceFor(cmbDevice2, key);
        }

        private void btnDetectBoth2_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            setDeviceFor(cmbDevice2, key);
            key.MapKeyInto(KeysUnderSetup.Value);
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnDetectKey1_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            key.MapKeyInto(KeysUnderSetup.Key);
            RefreshLabelsAndCheckboxesFrom();
        }

        private void btnDetectKey2_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            key.MapKeyInto(KeysUnderSetup.Value);
            RefreshLabelsAndCheckboxesTo();
        }

        private void chkIgnore_CheckedChanged(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.IgnoreKey = chkIgnore.Checked;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnSetFrom_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Key.Key = (ushort) numSignalCodeFrom.Value;
            RefreshLabelsAndCheckboxesFrom();
        }

        private void btnSetTo_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = (ushort)numSignalCodeTo.Value;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x19;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnPreviousTrack_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x10;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x24;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x22;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x20;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnVolUp_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x30;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnVolDown_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x2E;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnMediaSelect_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x6D;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x6C;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x21;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }

        private void btnMyComputer_Click(object sender, EventArgs e)
        {
            KeysUnderSetup.Value.Key = 0x6B;
            KeysUnderSetup.Value.FlagE0 = true;
            RefreshLabelsAndCheckboxesTo();
        }
    }
}
