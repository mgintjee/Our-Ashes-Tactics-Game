using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.Rgbs.Abstrs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractRgb
        : IRgb
    {
        // Todo
        protected ColorID colorID;

        // Todo
        protected int blue;

        // Todo
        protected int green;

        // Todo
        protected int red;

        /// <inheritdoc/>
        ColorID IRgb.GetColorID()
        {
            return this.colorID;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatBlue()
        {
            return this.blue / 255f;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatGreen()
        {
            return this.green / 255f;
        }

        /// <inheritdoc/>
        float IRgb.GetFloatRed()
        {
            return this.red / 255f;
        }

        /// <inheritdoc/>
        int IRgb.GetIntBlue()
        {
            return this.blue;
        }

        /// <inheritdoc/>
        int IRgb.GetIntGreen()
        {
            return this.green;
        }

        /// <inheritdoc/>
        int IRgb.GetIntRed()
        {
            return this.red;
        }
    }
}