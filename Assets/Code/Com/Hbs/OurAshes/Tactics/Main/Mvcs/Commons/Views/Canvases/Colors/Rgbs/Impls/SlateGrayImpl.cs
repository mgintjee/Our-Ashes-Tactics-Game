using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// SlateGray Rgb Implementation
    /// </summary>
    public class SlateGrayImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SlateGrayImpl()
        {
            this.colorID = ColorID.SlateGray;
            this.red = 112;
            this.green = 128;
            this.blue = 144;
        }
    }
}