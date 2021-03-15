using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.RGBs.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.RGBs.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct RGB
        : IRGB
    {
        // Todo
        private readonly int red;

        // Todo
        private readonly int green;

        // Todo
        private readonly int blue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public RGB(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        /// <inheritdoc/>
        float IRGB.GetFloatBlue()
        {
            return this.blue / 255f;
        }

        /// <inheritdoc/>
        float IRGB.GetFloatGreen()
        {
            return this.green / 255f;
        }

        /// <inheritdoc/>
        float IRGB.GetFloatRed()
        {
            return this.red / 255f;
        }

        /// <inheritdoc/>
        int IRGB.GetIntBlue()
        {
            return this.blue;
        }

        /// <inheritdoc/>
        int IRGB.GetIntGreen()
        {
            return this.green;
        }

        /// <inheritdoc/>
        int IRGB.GetIntRed()
        {
            return this.red;
        }
    }
}