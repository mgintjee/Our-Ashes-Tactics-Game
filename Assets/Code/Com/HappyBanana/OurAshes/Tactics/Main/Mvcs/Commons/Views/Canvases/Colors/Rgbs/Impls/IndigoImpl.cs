using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Indigo Rgb Implementation
    /// </summary>
    public class IndigoImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public IndigoImpl()
        {
            this.colorID = ColorID.Indigo;
            this.red = 75;
            this.green = 0;
            this.blue = 130;
        }
    }
}