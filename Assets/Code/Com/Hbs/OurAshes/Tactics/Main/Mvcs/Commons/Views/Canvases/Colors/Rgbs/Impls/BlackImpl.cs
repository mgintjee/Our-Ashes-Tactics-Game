using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Black Rgb Implementation
    /// </summary>
    public class BlackImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BlackImpl()
        {
            this.colorID = ColorID.Black;
            this.red = 0;
            this.green = 0;
            this.blue = 0;
        }
    }
}