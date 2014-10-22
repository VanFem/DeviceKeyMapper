using System.Collections.Generic;
using System.Windows.Forms;

namespace RawInput
{
    public partial class Form1 : Form
    {
        InputDevice id;
        int NumberOfKeyboards;

        public Form1()
        {
            InitializeComponent();

            // Create a new InputDevice object, get the number of
            // keyboards, and register the method which will handle the 
            // InputDevice KeyPressed event
            id = new InputDevice( Handle );
            NumberOfKeyboards = id.EnumerateDevices();
            cmbInputSelect.Items.AddRange(id.GetDeviceList());
            if (cmbInputSelect.Items.Count > 0)
            {
                cmbInputSelect.SelectedIndex = 0;
            }
            id.KeyPressed += m_KeyPressed;
        }
        
        // The WndProc is overridden to allow InputDevice to intercept
        // messages to the window and thus catch WM_INPUT messages
        protected override void WndProc( ref Message message )
        {
           if( id != null )
           {
               id.ProcessMessage( message );
           }
           base.WndProc( ref message );
        }

        private void m_KeyPressed( object sender, InputDevice.KeyControlEventArgs e )
        {
            //Replace() is just a cosmetic fix to stop ampersands turning into underlines
            lbHandle.Text = e.Keyboard.deviceHandle.ToString();
            lbType.Text = e.Keyboard.deviceType;
            lbName.Text = e.Keyboard.deviceName.Replace("&", "&&");
            lbDescription.Text = e.Keyboard.Name;         
            lbKey.Text = e.Keyboard.key.ToString();
            lbNumKeyboards.Text = NumberOfKeyboards.ToString();
            lbVKey.Text = e.Keyboard.vKey;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnMap_Click(object sender, System.EventArgs e)
        {

        }

    }
}