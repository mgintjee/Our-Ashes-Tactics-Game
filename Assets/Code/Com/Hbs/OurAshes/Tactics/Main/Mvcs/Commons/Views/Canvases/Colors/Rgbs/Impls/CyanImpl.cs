using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Cyan Rgb Implementation
    /// </summary>
    public class CyanImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CyanImpl()
        {
            this.colorID = ColorID.Cyan;
            this.red = 0;
            this.green = 255;
            this.blue = 255;
        }
    }
}