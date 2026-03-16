using System.Runtime.InteropServices;

namespace ScreenCapture.Model
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        public int DeviceId;
        public int State;
        public int Width;
        public int Height;
        public int Bpp; // 每个像素的位数
        public int Frequency;
    }
}
