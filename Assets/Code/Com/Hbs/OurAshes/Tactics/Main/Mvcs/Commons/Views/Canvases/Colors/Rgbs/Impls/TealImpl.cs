using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Impls
{
    /// <summary>
    /// Teal Rgb Implementation
    /// </summary>
    public class TealImpl
        : AbstractRgb
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TealImpl()
        {
            this.red = 0;
            this.green = 128;
            this.blue = 128;
        }
    }
}