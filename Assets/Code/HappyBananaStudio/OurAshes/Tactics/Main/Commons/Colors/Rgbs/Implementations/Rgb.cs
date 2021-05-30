using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.Rgbs.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct Rgb
        : IRgb
    {
        // Todo
        private readonly int blue;

        // Todo
        private readonly int green;

        // Todo
        private readonly int red;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="red">  </param>
        /// <param name="green"></param>
        /// <param name="blue"> </param>
        public Rgb(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
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