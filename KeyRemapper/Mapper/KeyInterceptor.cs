using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyRemapper.Mapper
{
    internal class KeyInterceptor
    {
        #region US Keyboard scancodes
        public static List<Keys> kbdus = new List<Keys>()
        {
            Keys.None,
            Keys.Escape,
            Keys.D1,
            Keys.D2,
            Keys.D3,
            Keys.D4,
            Keys.D5,
            Keys.D6,
            Keys.D7,
            Keys.D8,
            /* 9 */
            Keys.D9,
            Keys.D0,
            Keys.OemMinus,
            Keys.Oemplus,
            Keys.Back,
            /* Backspace */
            Keys.Tab,
            /* Tab */
            Keys.Q,
            Keys.W,
            Keys.E,
            Keys.R,
            /* 19 */
            Keys.T,
            Keys.Y,
            Keys.U,
            Keys.I,
            Keys.O,
            Keys.P,
            Keys.OemOpenBrackets,
            Keys.Oem6,
            Keys.Return,
            /* Enter key */
            Keys.ControlKey,
            /* 29   - Control */
            Keys.A,
            Keys.S,
            Keys.D,
            Keys.F,
            Keys.G,
            Keys.H,
            Keys.J,
            Keys.K,
            Keys.L,
            Keys.Oem1,
            /* 39 */
            Keys.Oem7,
            Keys.Oemtilde,
            Keys.LShiftKey,
            /* Left shift */
            Keys.Oem5,
            Keys.Z,
            Keys.X,
            Keys.C,
            Keys.V,
            Keys.B,
            Keys.N,
            /* 49 */
            Keys.M,
            Keys.Oemcomma,
            Keys.OemPeriod,
            Keys.OemQuestion,
            Keys.RShiftKey,
            /* Right shift */
            Keys.Multiply,
            Keys.Alt,
            /* Alt */
            Keys.Space,
            /* Space bar */
            Keys.Capital,
            /* Caps lock */
            Keys.F1,
            /* 59 - F1 key ... > */
            Keys.F2,
            Keys.F3,
            Keys.F4,
            Keys.F5,
            Keys.F6,
            Keys.F7,
            Keys.F8,
            Keys.F9,
            Keys.F10,
            /* < ... F10 */
            Keys.NumLock,
            /* 69 - Num lock*/
            Keys.Scroll,
            /* Scroll Lock */
            Keys.Home,
            /* Home key */
            Keys.Up,
            /* Up Arrow */
            Keys.PageUp,
            /* Page Up */
            Keys.Subtract,
            Keys.Left,
            /* Left Arrow */
            Keys.Clear,
            Keys.Right,
            /* Right Arrow */
            Keys.Add,
            Keys.End,
            /* 79 - End key*/
            Keys.Down,
            /* Down Arrow */
            Keys.PageDown,
            /* Page Down */
            Keys.Insert,
            /* Insert Key */
            Keys.Delete,
            /* Delete Key */
            0,
            0,
            0,
            Keys.F11,
            /* F11 Key */
            Keys.F12,
            /* F12 Key */
            0,
            /* All other keys are undefined */
        };
        #endregion US Keyboard scancodes

        #region Enums

        [Flags]
        private enum InterceptionKeyState
        {
            INTERCEPTION_KEY_DOWN = 0x00,
            INTERCEPTION_KEY_UP = 0x01,
            INTERCEPTION_KEY_E0 = 0x02,
            INTERCEPTION_KEY_E1 = 0x04,
            INTERCEPTION_KEY_TERMSRV_SET_LED = 0x08,
            INTERCEPTION_KEY_TERMSRV_SHADOW = 0x10,
            INTERCEPTION_KEY_TERMSRV_VKPACKET = 0x20
        };

        [Flags]
        private enum InterceptionFilterKeyState
        {
            INTERCEPTION_FILTER_KEY_NONE = 0x0000,
            INTERCEPTION_FILTER_KEY_ALL = 0xFFFF,
            INTERCEPTION_FILTER_KEY_DOWN = InterceptionKeyState.INTERCEPTION_KEY_UP,
            INTERCEPTION_FILTER_KEY_UP = InterceptionKeyState.INTERCEPTION_KEY_UP << 1,
            INTERCEPTION_FILTER_KEY_E0 = InterceptionKeyState.INTERCEPTION_KEY_E0 << 1,
            INTERCEPTION_FILTER_KEY_E1 = InterceptionKeyState.INTERCEPTION_KEY_E1 << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_SET_LED = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_SET_LED << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_SHADOW = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_SHADOW << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_VKPACKET = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_VKPACKET << 1
        };

        [Flags]
        private enum InterceptionMouseState
        {
            INTERCEPTION_MOUSE_LEFT_BUTTON_DOWN = 0x001,
            INTERCEPTION_MOUSE_LEFT_BUTTON_UP = 0x002,
            INTERCEPTION_MOUSE_RIGHT_BUTTON_DOWN = 0x004,
            INTERCEPTION_MOUSE_RIGHT_BUTTON_UP = 0x008,
            INTERCEPTION_MOUSE_MIDDLE_BUTTON_DOWN = 0x010,
            INTERCEPTION_MOUSE_MIDDLE_BUTTON_UP = 0x020,

            INTERCEPTION_MOUSE_BUTTON_1_DOWN = INTERCEPTION_MOUSE_LEFT_BUTTON_DOWN,
            INTERCEPTION_MOUSE_BUTTON_1_UP = INTERCEPTION_MOUSE_LEFT_BUTTON_UP,
            INTERCEPTION_MOUSE_BUTTON_2_DOWN = INTERCEPTION_MOUSE_RIGHT_BUTTON_DOWN,
            INTERCEPTION_MOUSE_BUTTON_2_UP = INTERCEPTION_MOUSE_RIGHT_BUTTON_UP,
            INTERCEPTION_MOUSE_BUTTON_3_DOWN = INTERCEPTION_MOUSE_MIDDLE_BUTTON_DOWN,
            INTERCEPTION_MOUSE_BUTTON_3_UP = INTERCEPTION_MOUSE_MIDDLE_BUTTON_UP,

            INTERCEPTION_MOUSE_BUTTON_4_DOWN = 0x040,
            INTERCEPTION_MOUSE_BUTTON_4_UP = 0x080,
            INTERCEPTION_MOUSE_BUTTON_5_DOWN = 0x100,
            INTERCEPTION_MOUSE_BUTTON_5_UP = 0x200,

            INTERCEPTION_MOUSE_WHEEL = 0x400,
            INTERCEPTION_MOUSE_HWHEEL = 0x800
        };

        [Flags]
        private enum InterceptionFilterMouseState
        {
            INTERCEPTION_FILTER_MOUSE_NONE = 0x0000,
            INTERCEPTION_FILTER_MOUSE_ALL = 0xFFFF,

            INTERCEPTION_FILTER_MOUSE_LEFT_BUTTON_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_LEFT_BUTTON_DOWN,
            INTERCEPTION_FILTER_MOUSE_LEFT_BUTTON_UP = InterceptionMouseState.INTERCEPTION_MOUSE_LEFT_BUTTON_UP,
            INTERCEPTION_FILTER_MOUSE_RIGHT_BUTTON_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_RIGHT_BUTTON_DOWN,
            INTERCEPTION_FILTER_MOUSE_RIGHT_BUTTON_UP = InterceptionMouseState.INTERCEPTION_MOUSE_RIGHT_BUTTON_UP,
            INTERCEPTION_FILTER_MOUSE_MIDDLE_BUTTON_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_MIDDLE_BUTTON_DOWN,
            INTERCEPTION_FILTER_MOUSE_MIDDLE_BUTTON_UP = InterceptionMouseState.INTERCEPTION_MOUSE_MIDDLE_BUTTON_UP,

            INTERCEPTION_FILTER_MOUSE_BUTTON_1_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_1_DOWN,
            INTERCEPTION_FILTER_MOUSE_BUTTON_1_UP = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_1_UP,
            INTERCEPTION_FILTER_MOUSE_BUTTON_2_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_2_DOWN,
            INTERCEPTION_FILTER_MOUSE_BUTTON_2_UP = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_2_UP,
            INTERCEPTION_FILTER_MOUSE_BUTTON_3_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_3_DOWN,
            INTERCEPTION_FILTER_MOUSE_BUTTON_3_UP = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_3_UP,

            INTERCEPTION_FILTER_MOUSE_BUTTON_4_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_4_DOWN,
            INTERCEPTION_FILTER_MOUSE_BUTTON_4_UP = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_4_UP,
            INTERCEPTION_FILTER_MOUSE_BUTTON_5_DOWN = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_5_DOWN,
            INTERCEPTION_FILTER_MOUSE_BUTTON_5_UP = InterceptionMouseState.INTERCEPTION_MOUSE_BUTTON_5_UP,

            INTERCEPTION_FILTER_MOUSE_WHEEL = InterceptionMouseState.INTERCEPTION_MOUSE_WHEEL,
            INTERCEPTION_FILTER_MOUSE_HWHEEL = InterceptionMouseState.INTERCEPTION_MOUSE_HWHEEL,

            INTERCEPTION_FILTER_MOUSE_MOVE = 0x1000
        };

        [Flags]
        private enum InterceptionMouseFlag
        {
            INTERCEPTION_MOUSE_MOVE_RELATIVE = 0x000,
            INTERCEPTION_MOUSE_MOVE_ABSOLUTE = 0x001,
            INTERCEPTION_MOUSE_VIRTUAL_DESKTOP = 0x002,
            INTERCEPTION_MOUSE_ATTRIBUTES_CHANGED = 0x004,
            INTERCEPTION_MOUSE_MOVE_NOCOALESCE = 0x008,
            INTERCEPTION_MOUSE_TERMSRV_SRC_SHADOW = 0x100
        };

        #endregion

        #region Structs

        private struct InterceptionMouseStroke
        {
            public ushort state;
            public ushort flags;
            public short rolling;
            public int x;
            public int y;
            public uint information;
        }

        private struct InterceptionKeyStroke
        {
            public ushort code;
            public ushort state;
            public uint information;
        };

        private struct KEYBOARD_INPUT_DATA
        {
            public ushort UnitId;
            public ushort MakeCode;
            public ushort Flags;
            public ushort Reserved;
            public ushort ExtraInformation;
        }

        private struct MOUSE_INPUT_DATA
        {
            public ushort UnitId;
            public ushort Flags;
            public ushort ButtonFlags;
            public ushort ButtonData;
            public ulong RawButtons;
            public long LastX;
            public long LastY;
            public ulong ExtraInformation;
        }

        private struct InterceptionDeviceArray
        {
            public IntPtr handle;
            public IntPtr unempty;
        }

        #endregion

        #region DLL Imports

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int InterceptionPredicateFunc(int device);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr interception_create_context();

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void interception_destroy_context(IntPtr context);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_get_precedence(IntPtr context, int device);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void interception_set_precedence(IntPtr context, int device, int precedence);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern ushort interception_get_filter(IntPtr context, int device);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void interception_set_filter(IntPtr context,
            [MarshalAs(UnmanagedType.FunctionPtr)] InterceptionPredicateFunc func, ushort filter);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_wait(IntPtr context);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_wait_with_timeout(IntPtr context, ulong milliseconds);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_send(IntPtr context, int device, IntPtr stroke, uint nstroke);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_receive(IntPtr context, int device, IntPtr stroke, uint nstroke);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern uint interception_get_hardware_id(IntPtr context, int device, IntPtr hardware_id_buffer,
            uint buffer_size);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_is_invalid(int device);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_is_keyboard(int device);

        [DllImport("interception.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int interception_is_mouse(int device);

        #endregion DLL Imports

        #region Statics
        #endregion Statics

        #region Constants

        private const int INTERCEPTOR_MAX_DEVICES = 20;
        #endregion

        public List<DeviceDef> GetKeyboardDevices()
        {
            var context = interception_create_context();
            var deviceHids = new List<DeviceDef>();
            
            for (int i = 0; i < INTERCEPTOR_MAX_DEVICES; i++)
            {
                if (interception_is_keyboard(i) == 0) continue;
                
                var hid = GetHardwareId(context, i);
                if (string.IsNullOrEmpty(hid)) continue;
                
                deviceHids.Add(new DeviceDef{HID=hid, DeviceIndex = i});
            }
            interception_destroy_context(context);
            return deviceHids;
        }

        public List<DeviceDef> GetDevices()
        {
            var context = interception_create_context();
            var deviceHids = new List<DeviceDef>();

            for (int i = 0; i < INTERCEPTOR_MAX_DEVICES; i++)
            {
                var hid = GetHardwareId(context, i);
                if (string.IsNullOrEmpty(hid)) continue;
                deviceHids.Add(new DeviceDef { HID = hid, DeviceIndex = i });
            }
            interception_destroy_context(context);
            return deviceHids;
        }



        public KeyDef GetNextPressedKey()
        {
            var context = interception_create_context();
            IntPtr stroke = Marshal.AllocHGlobal(20);
            int device;
            var kdef = new KeyDef();

            interception_set_filter(context, interception_is_keyboard,(ushort) InterceptionFilterKeyState.INTERCEPTION_FILTER_KEY_ALL);

            if (interception_receive(context, device = interception_wait(context), stroke, 1) > 0)
            {
                kdef.DeviceInfo = new DeviceDef {DeviceIndex = device, HID = GetHardwareId(context, device)};
                var kstroke =(InterceptionKeyStroke)Marshal.PtrToStructure(stroke, typeof (InterceptionKeyStroke));
                kdef.Key = kstroke.code;
                kdef.FlagE0 = IsE0(kstroke.state);
                kdef.FlagE1 = IsE1(kstroke.state);
            }
            interception_destroy_context(context);

            return kdef;
        }

        private string GetHardwareId(IntPtr context, int deviceId)
        {
            IntPtr hardware_id = Marshal.AllocHGlobal(500);
            uint length = interception_get_hardware_id(context, deviceId, hardware_id, 500);

            if (length > 0 && length < 500)
                return Marshal.PtrToStringAuto(hardware_id);
            return string.Empty;
        }

        public void RunMapping(Mapper mapper)
        {
            var context = interception_create_context();
            var deviceHids = new List<DeviceDef>();
            for (int i = 0; i < INTERCEPTOR_MAX_DEVICES; i++)
            {
                var hid = GetHardwareId(context, i);
                if (string.IsNullOrEmpty(hid)) continue;
                deviceHids.Add(new DeviceDef { HID = hid, DeviceIndex = i });
            }

            IntPtr stroke = Marshal.AllocHGlobal(20);
            int device;
            
            interception_set_filter(context, interception_is_keyboard, (ushort)InterceptionFilterKeyState.INTERCEPTION_FILTER_KEY_ALL);

            while (mapper.Armed)
            {
                if (interception_receive(context, device = interception_wait_with_timeout(context, 500), stroke, 1) > 0)
                {
                    var kstroke = (InterceptionKeyStroke) Marshal.PtrToStructure(stroke, typeof (InterceptionKeyStroke));
                    var newKey =
                        mapper.RemapKey(new KeyDef
                        {
                            DeviceInfo = deviceHids.Single(d => d.DeviceIndex == device),
                            Key = kstroke.code,
                            FlagE0 = IsE0(kstroke.state),
                            FlagE1 = IsE1(kstroke.state),
                        });
                    if (deviceHids.Count(d => d.HID == newKey.DeviceInfo.HID) == 1)
                    {
                        newKey.DeviceInfo.DeviceIndex =
                            deviceHids.Single(d => d.HID == newKey.DeviceInfo.HID).DeviceIndex;
                    }
                    else if (deviceHids.Count(d => d.ToString() == newKey.DeviceInfo.ToString()) != 1)
                    {
                        interception_send(context, device, stroke, 1);
                        continue;
                    }
                    Debug.Write(string.Format("Mapped code {0} status {1} to ",kstroke.code, kstroke.state));
                    kstroke.code = newKey.Key;
                    kstroke.state = SetState(InterceptionKeyState.INTERCEPTION_KEY_E0, newKey.FlagE0, kstroke.state);
                    kstroke.state = SetState(InterceptionKeyState.INTERCEPTION_KEY_E1, newKey.FlagE1, kstroke.state);
                    Debug.WriteLine("{0}, {1}", kstroke.code, kstroke.state);
                    Marshal.StructureToPtr(kstroke, stroke, true);
                    interception_send(context, newKey.DeviceInfo.DeviceIndex, stroke, 1);
                }
            }
            interception_destroy_context(context);
            
        }

        

        private bool IsE0(ushort state)
        {
            return (state & (ushort)InterceptionKeyState.INTERCEPTION_KEY_E0) != 0;
        }

        private bool IsE1(ushort state)
        {
            return (state & (ushort)InterceptionKeyState.INTERCEPTION_KEY_E1) != 0;
        }

        private bool IsUp(ushort state)
        {
            return (state & (ushort)InterceptionKeyState.INTERCEPTION_KEY_UP) != 0;
        }

        private ushort SetState(InterceptionKeyState setState, bool toEnabled, ushort currentState)
        {
            if (toEnabled)
            {
                return (ushort) (currentState | (ushort) setState);
            }
            return (ushort) (currentState & (~(int) setState & 0xFFFF));
        }
    }
}

