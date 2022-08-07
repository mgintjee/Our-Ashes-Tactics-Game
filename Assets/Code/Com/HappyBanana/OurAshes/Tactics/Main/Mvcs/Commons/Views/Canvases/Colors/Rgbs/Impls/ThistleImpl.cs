using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Thistle Rgb Implementation
    /// </summary>
    public class ThistleImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ThistleImpl()
        {
            this.colorID = ColorID.Thistle;
            this.red = 216;
            this.green = 191;
            this.blue = 216;
        }
    }
}