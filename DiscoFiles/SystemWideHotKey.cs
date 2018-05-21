using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DaylightComputers
{
    class SystemWideHotKey
    {
        #region fields
        public static int MOD_ALT = 0x1;
        public static int MOD_CONTROL = 0x2;
        public static int MOD_SHIFT = 0x4;
        public static int MOD_WIN = 0x8;
        public static int WM_HOTKEY = 0x312;
        #endregion

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static int keyId;
        public static void RegisterHotKey(Form _inForm, Keys _inKey)
        {
            int modifiers = 0;

            if ((_inKey & Keys.Alt) == Keys.Alt)
                modifiers = modifiers | SystemWideHotKey.MOD_ALT;

            if ((_inKey & Keys.Control) == Keys.Control)
                modifiers = modifiers | SystemWideHotKey.MOD_CONTROL;

            if ((_inKey & Keys.Shift) == Keys.Shift)
                modifiers = modifiers | SystemWideHotKey.MOD_SHIFT;

            Keys k = _inKey & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;

            Func DelegMethod = delegate()
            {
                keyId = _inForm.GetHashCode(); // this should be a key unique ID, modify this if you want more than one hotkey
                RegisterHotKey((IntPtr)_inForm.Handle, keyId, modifiers, (int)k);
            };

            _inForm.Invoke(DelegMethod); // this should be checked if we really need it (InvokeRequired), but it's faster this way
        }

        private delegate void Func();

        public static void UnregisterHotKey(Form _inForm)
        {
            try
            {
                Func DelegMethod = delegate()
                {
                    UnregisterHotKey(_inForm.Handle, keyId); // modify this if you want more than one hotkey
                };

                _inForm.Invoke(DelegMethod); // this should be checked if we really need it (InvokeRequired), but it's faster this way
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
