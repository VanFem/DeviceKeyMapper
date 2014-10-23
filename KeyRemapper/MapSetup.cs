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
    public partial class MapSetup : Form
    {
        private KeyInterceptor kInterceptor = new KeyInterceptor();
        private KeyDetect kDetect;
     
        private List<DeviceDef> devicesList;

        public KeyValuePair<KeyDef, KeyDef> KeysUnderSetup;

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

            RefreshLabels();

            if (!cmbDevice1.Items.Contains(initialKeys.Key.DeviceInfo.ToString()) || !cmbDevice2.Items.Contains(initialKeys.Value.DeviceInfo.ToString()))
            {
                MessageBox.Show("This map does not correspond to any active device.");
                return;
            }

            cmbDevice1.SelectedItem = initialKeys.Key.DeviceInfo.ToString();
            cmbDevice2.SelectedItem = initialKeys.Value.DeviceInfo.ToString();
        }

        private void RefreshLabels()
        {
            lblKey1.Text = KeysUnderSetup.Key.Key + " (" +
                           (KeysUnderSetup.Key.Key < KeyInterceptor.kbdus.Count
                               ? Enum.GetName(typeof (Keys), KeyInterceptor.kbdus[KeysUnderSetup.Key.Key])
                               : "") + ")";
            lblKey2.Text = KeysUnderSetup.Value.Key + " (" +
                           (KeysUnderSetup.Value.Key < KeyInterceptor.kbdus.Count
                               ? Enum.GetName(typeof(Keys), KeyInterceptor.kbdus[KeysUnderSetup.Value.Key])
                               : "") + ")";
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
            KeysUnderSetup.Key.Key = key.Key;
            RefreshLabels();
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
            KeysUnderSetup.Value.Key = key.Key;
            RefreshLabels();
        }

        private void btnDetectKey1_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            KeysUnderSetup.Key.Key = key.Key;
            RefreshLabels();
        }

        private void btnDetectKey2_Click(object sender, EventArgs e)
        {
            var key = AskForKey();
            KeysUnderSetup.Value.Key = key.Key;
            RefreshLabels();
        }
    }
}
