using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Fuchsia Rgb Implementation
    /// </summary>
    public class FuchsiaImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FuchsiaImpl()
        {
            this.colorID = ColorID.Fuchsia;
            this.red = 255;
            this.green = 0;
            this.blue = 255;
        }
    }
}