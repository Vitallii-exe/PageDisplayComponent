namespace PageDisplay
{
    public class CustomPictureBox : PictureBox
    {
        const int WM_MOUSEWHEEL = 0x020A;
        const int MK_CONTROL = 0x8;

        public delegate void ScaleChanged(bool up);
        public event ScaleChanged scaleChanged;
        private (int, int) SplitWParam(IntPtr _wParam)
        {
            uint wParam = unchecked(IntPtr.Size == 8 ? (uint)_wParam.ToInt64() : (uint)_wParam.ToInt32());
            int lowOrder = unchecked((short)wParam);
            int highOrder = unchecked((short)(wParam >> 16));
            return (lowOrder, highOrder);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL)
            {
                (int withKey, int delta) wParam = SplitWParam(m.WParam);
                if (wParam.withKey == MK_CONTROL)
                {
                    if (wParam.delta == 120) //If wheel rotated forward
                    {
                        scaleChanged?.Invoke(true);
                    }
                    else //If wheel rotated backward
                    {
                        scaleChanged?.Invoke(false);
                    }
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
