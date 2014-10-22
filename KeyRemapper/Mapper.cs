using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput;

namespace KeyRemapper
{
    static class Mapper
    {
        #region const definitions

        // The following constants are defined in Windows.h

        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RID_INPUT = 0x10000003;

        private const int FAPPCOMMAND_MASK = 0xF000;
        private const int FAPPCOMMAND_MOUSE = 0x8000;
        private const int FAPPCOMMAND_OEM = 0x1000;

        private const int RIM_TYPEMOUSE = 0;
        private const int RIM_TYPEKEYBOARD = 1;
        private const int RIM_TYPEHID = 2;

        private const int RIDI_DEVICENAME = 0x20000007;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_INPUT = 0x00FF;
        private const int VK_OEM_CLEAR = 0xFE;
        private const int VK_LAST_KEY = VK_OEM_CLEAR; // this is a made up value used as a sentinel

        #endregion const definitions

        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        public static List<MappedKey> MapList = new List<MappedKey>();

        public static void Map(ref Message message)
        {
            uint dwSize = 0;

            // First call to GetRawInputData sets the value of dwSize,
            // which can then be used to allocate the appropriate amount of memory,
            // storing the pointer in "buffer".
            GetRawInputData(message.LParam,
                             RID_INPUT, IntPtr.Zero,
                             ref dwSize,
                             (uint)Marshal.SizeOf(typeof(InputDevice.RAWINPUTHEADER)));

            IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
            try
            {
                // Check that buffer points to something, and if so,
                // call GetRawInputData again to fill the allocated memory
                // with information about the input
                if (buffer != IntPtr.Zero &&
                    GetRawInputData(message.LParam,
                                     RID_INPUT,
                                     buffer,
                                     ref dwSize,
                                     (uint)Marshal.SizeOf(typeof(InputDevice.RAWINPUTHEADER))) == dwSize)
                {
                    // Store the message information in "raw", then check
                    // that the input comes from a keyboard device before
                    // processing it to raise an appropriate KeyPressed event.

                    InputDevice.RAWINPUT raw = (InputDevice.RAWINPUT)Marshal.PtrToStructure(buffer, typeof(InputDevice.RAWINPUT));

                    if (raw.header.dwType == RIM_TYPEKEYBOARD)
                    {
                        // Filter for Key Down events and then retrieve information 
                        // about the keystroke
                        if (raw.keyboard.Message == WM_KEYDOWN || raw.keyboard.Message == WM_SYSKEYDOWN)
                        {

                            ushort key = raw.keyboard.VKey;

                            // On most keyboards, "extended" keys such as the arrow or 
                            // page keys return two codes - the key's own code, and an
                            // "extended key" flag, which translates to 255. This flag
                            // isn't useful to us, so it can be disregarded.
                            if (key > VK_LAST_KEY)
                            {
                                return;
                            }

                            // Retrieve information about the device and the
                            // key that was pressed.
                            InputDevice.DeviceInfo dInfo = null;

                            if (deviceList.Contains(raw.header.hDevice))
                            {
                                Keys myKey;

                                dInfo = (InputDevice.DeviceInfo)deviceList[raw.header.hDevice];

                                myKey = (Keys)Enum.Parse(typeof(Keys), Enum.GetName(typeof(Keys), key));
                                dInfo.vKey = myKey.ToString();
                                dInfo.key = key;
                            }
                            else
                            {
                                string errMessage = String.Format("Handle :{0} was not in hashtable. The device may support more than one handle or usage page, and is probably not a standard keyboard.", raw.header.hDevice);
                                throw new ApplicationException(errMessage);
                            }

                            // If the key that was pressed is valid and there
                            // was no problem retrieving information on the device,
                            // raise the KeyPressed event.
                            if (KeyPressed != null && dInfo != null)
                            {
                                KeyPressed(this, new InputDevice.KeyControlEventArgs(dInfo, GetDevice(message.LParam.ToInt32())));
                            }
                            else
                            {
                                string errMessage = String.Format("Received Unknown Key: {0}. Possibly an unknown device", key);
                                throw new ApplicationException(errMessage);
                            }
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

    }
}
