using System.Drawing;

namespace ScreenCapture.Model
{
    /// <summary>
    /// 屏幕信息
    /// </summary>
    public class ScreenInfo
    {
        /// <summary>
        /// 屏幕索引编号
        /// </summary>
        public uint Index { get; set; }

        /// <summary>
        /// 屏幕名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 主显示器
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 显卡名称
        /// </summary>
        public string DeviceName { get; set; } = string.Empty;

        /// <summary>
        /// 显示器边界
        /// </summary>
        public Rectangle MonitorSize { get; set; } = new Rectangle();

        /// <summary>
        /// 显示器边界
        /// </summary>
        public Rectangle WorkSize { get; set; } = new Rectangle();

        /// <summary>
        /// 每逻辑英寸的像素数
        /// </summary>
        public ushort LogPixels { get; set; }

        /// <summary>
        /// 显示宽度（像素）
        /// </summary>
        public uint PhysicsWidth { get; set; }

        /// <summary>
        /// 显示高度（像素）
        /// </summary>
        public uint PhysicsHeight { get; set; }

        /// <summary>
        /// 显示宽度（像素）
        /// </summary>
        public uint LogicalWidth { get; set; }

        /// <summary>
        /// 显示高度（像素）
        /// </summary>
        public uint LogicalHeigh { get; set; }

        /// <summary>
        /// 颜色深度
        /// </summary>
        public uint BitsPerPel { get; set; }

        /// <summary>
        /// 显示频率
        /// </summary>
        public uint DisplayFrequency { get; set; }

        public override string ToString()
        {
            return $"Index: {Index}, Name: {Name}, DeviceName: {DeviceName}, IsPrimary: {IsPrimary}, IsActive: {IsActive}, MonitorSize: {MonitorSize}, WorkSize: {WorkSize}, LogPixels: {LogPixels}, Width: {PhysicsWidth}, Height: {PhysicsHeight}, BitsPerPel: {BitsPerPel}, DisplayFrequency: {DisplayFrequency}";
        }
    }
}
