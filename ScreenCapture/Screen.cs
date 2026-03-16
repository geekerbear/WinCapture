using ScreenCapture.Model;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;

namespace ScreenCapture
{
    /// <summary>
    /// 屏幕操作
    /// </summary>
    public class Screen
    {
        [SupportedOSPlatform("windows5.0")]
        public ScreenInfo[] GetScreens()
        {
            List<ScreenInfo> screens = [];
            uint deviceIndex = 0;
            DISPLAY_DEVICEW displayDevice = new()
            {
                cb = (uint)Marshal.SizeOf<DISPLAY_DEVICEW>()
            };

            

            uint index = 1;
            unsafe
            {
                MONITORENUMPROC enumCallback = new((hMonitor, hdcMonitor, lprcMonitorPtr, dwData) =>
                {
                    ScreenInfo info = new()
                    {
                        Index = index++
                    };

                    MONITORINFO monitorInfo = new()
                    {
                        cbSize = (uint)Marshal.SizeOf<MONITORINFO>()
                    };

                    if (PInvoke.GetMonitorInfo(hMonitor, ref monitorInfo))
                    {
                        info.LogicalWidth = (uint)(monitorInfo.rcMonitor.right - monitorInfo.rcMonitor.left);
                        info.LogicalHeigh = (uint)(monitorInfo.rcMonitor.bottom - monitorInfo.rcMonitor.top);
                        info.MonitorSize = new System.Drawing.Rectangle(monitorInfo.rcMonitor.left, monitorInfo.rcMonitor.top, monitorInfo.rcMonitor.right - monitorInfo.rcMonitor.left, monitorInfo.rcMonitor.bottom - monitorInfo.rcMonitor.top);
                        info.WorkSize = new System.Drawing.Rectangle(monitorInfo.rcWork.left, monitorInfo.rcWork.top, monitorInfo.rcWork.right - monitorInfo.rcWork.left, monitorInfo.rcWork.bottom - monitorInfo.rcWork.top);
                        Console.WriteLine($"显示器区域: Left={monitorInfo.rcMonitor.left}, Top={monitorInfo.rcMonitor.top}, Right={monitorInfo.rcMonitor.right}, Bottom={monitorInfo.rcMonitor.bottom}");
                    }
                    return true;  // Continue enumeration
                });

                PInvoke.EnumDisplayMonitors(new Windows.Win32.Graphics.Gdi.HDC(IntPtr.Zero), null, enumCallback, IntPtr.Zero);
            }


            while (PInvoke.EnumDisplayDevices(null, deviceIndex, ref displayDevice, 0) != 0)
            {
                DEVMODEW devMODEW = new();
                PInvoke.EnumDisplaySettingsEx(displayDevice.DeviceName.ToString(), ENUM_DISPLAY_SETTINGS_MODE.ENUM_CURRENT_SETTINGS, ref devMODEW, ENUM_DISPLAY_SETTINGS_FLAGS.EDS_RAWMODE);

                screens.Add(new ScreenInfo
                {
                    Index = deviceIndex + 1,
                    Name = displayDevice.DeviceName.ToString(),
                    DeviceName = displayDevice.DeviceString.ToString(),
                    IsPrimary  = (displayDevice.StateFlags & DISPLAY_DEVICE_STATE_FLAGS.DISPLAY_DEVICE_PRIMARY_DEVICE) != 0,
                    IsActive = (displayDevice.StateFlags & DISPLAY_DEVICE_STATE_FLAGS.DISPLAY_DEVICE_ACTIVE) != 0,
                    PhysicsWidth = devMODEW.dmPelsWidth,
                    PhysicsHeight = devMODEW.dmPelsHeight,
                    BitsPerPel = devMODEW.dmBitsPerPel,
                    DisplayFrequency = devMODEW.dmDisplayFrequency,
                    LogPixels = devMODEW.dmLogPixels
                });

                




                



                deviceIndex++;

                
            }

            return [.. screens];
        }
    }
}
