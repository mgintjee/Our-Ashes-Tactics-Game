using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Salmon Rgb Implementation
    /// </summary>
    public class SalmonImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SalmonImpl()
        {
            this.colorID = ColorID.Salmon;
            this.red = 250;
            this.green = 128;
            this.blue = 114;
        }
    }
}