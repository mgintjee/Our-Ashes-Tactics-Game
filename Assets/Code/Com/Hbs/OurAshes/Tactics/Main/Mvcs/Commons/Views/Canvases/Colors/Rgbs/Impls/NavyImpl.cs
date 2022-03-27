using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Navy Rgb Implementation
    /// </summary>
    public class NavyImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NavyImpl()
        {
            this.colorID = ColorID.Navy;
            this.red = 0;
            this.green = 0;
            this.blue = 128;
        }
    }
}