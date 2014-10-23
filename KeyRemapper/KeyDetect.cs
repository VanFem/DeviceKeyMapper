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
    public partial class KeyDetect : Form
    {
        public KeyDef ReceivedKey;

        public KeyDetect()
        {
            InitializeComponent();
        }

        private void WaitForKey(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            KeyInterceptor ki = new KeyInterceptor();
            ReceivedKey = ki.GetNextPressedKey();
            DialogResult = DialogResult.OK;
        }

        private void CloseForm(object sender, RunWorkerCompletedEventArgs workerCompletedEventArgs)
        {
            Close();
        }
        
        private void KeyDetect_Shown(object sender, EventArgs e)
        {
            var bgworker = new BackgroundWorker();
            bgworker.DoWork += WaitForKey;
            bgworker.RunWorkerCompleted += CloseForm;
            bgworker.RunWorkerAsync();
        }
    }
}
