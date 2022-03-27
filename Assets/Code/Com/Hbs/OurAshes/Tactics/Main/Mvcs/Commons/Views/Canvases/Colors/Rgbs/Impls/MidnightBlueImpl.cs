using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// MidnightBlue Rgb Implementation
    /// </summary>
    public class MidnightBlueImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MidnightBlueImpl()
        {
            this.colorID = ColorID.MidnightBlue;
            this.red = 25;
            this.green = 25;
            this.blue = 112;
        }
    }
}