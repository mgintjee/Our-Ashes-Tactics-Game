using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Olive Rgb Implementation
    /// </summary>
    public class OliveImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public OliveImpl()
        {
            this.colorID = ColorID.Olive;
            this.red = 128;
            this.green = 128;
            this.blue = 0;
        }
    }
}