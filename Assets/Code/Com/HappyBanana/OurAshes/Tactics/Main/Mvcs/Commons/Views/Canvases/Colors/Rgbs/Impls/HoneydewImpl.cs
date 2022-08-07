using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Honeydew Rgb Implementation
    /// </summary>
    public class HoneydewImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HoneydewImpl()
        {
            this.colorID = ColorID.HoneyDew;
            this.red = 240;
            this.green = 255;
            this.blue = 240;
        }
    }
}