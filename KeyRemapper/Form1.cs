using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using KeyRemapper;
using KeyRemapper.Mapper;

namespace RawInput
{
    public partial class Form1 : Form
    {
        private Mapper mapper = new Mapper();
        private InputDevice id;
        private int NumberOfKeyboards;
        private BackgroundWorker bw;
        private static readonly string ConfigFileName = "map.config";
        
        

        public Form1()
        {
            InitializeComponent();

            // Create a new InputDevice object, get the number of
            // keyboards, and register the method which will handle the 
            // InputDevice KeyPressed event
            id = new InputDevice( Handle );
            NumberOfKeyboards = id.EnumerateDevices();
            bw = new BackgroundWorker();
            bw.DoWork += RunMapping;
            bw.RunWorkerCompleted += WorkCompleted;
            id.KeyPressed += m_KeyPressed;
            ReadConfigFromFile();
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Text = "Arm mapping";
            mapper.Armed = false;
            button1.Enabled = true;
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
            var mapperConfig = new MapperConfig(mapper);
            mapperConfig.ShowDialog();
            WriteConfigToFile();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (mapper.Armed)
            {
                mapper.Armed = false;
                button1.Text = "Stopping...";
                button1.Enabled = false;
                return;
            }
            button1.Text = "Disarm mapping";
            bw.RunWorkerAsync();
        }

        private void RunMapping(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var keyInterceptor = new KeyInterceptor();
            mapper.Armed = true;
            keyInterceptor.RunMapping(mapper);
        }

        private void WriteConfigToFile()
        {
            var xser = new XmlSerializer(typeof(MapperConfiguration));
            TextWriter tw = new StreamWriter(ConfigFileName, false);
            xser.Serialize(tw, mapper.CreateConfig());
        }

        private void ReadConfigFromFile()
        {
            if (File.Exists(ConfigFileName))
            {
                try
                {
                    var xser = new XmlSerializer(typeof (MapperConfiguration));
                    using (TextReader textreader = new StreamReader(ConfigFileName))
                    {
                        mapper.ReadConfig((MapperConfiguration) xser.Deserialize(textreader));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Cannot read configuration: " + e.Message);
                }
            }
        }

    }
}