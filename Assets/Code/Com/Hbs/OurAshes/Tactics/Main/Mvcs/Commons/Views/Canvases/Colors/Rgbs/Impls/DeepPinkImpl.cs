using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// DeepPink Rgb Implementation
    /// </summary>
    public class DeepPinkImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DeepPinkImpl()
        {
            this.colorID = ColorID.DeepPink;
            this.red = 255;
            this.green = 20;
            this.blue = 147;
        }
    }
}