namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Attributes.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Attributes.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileAttributesImpl
        : IHexTileAttributes
    {
        // Todo
        private readonly float moveCost;

        // Todo
        private readonly float fireCost;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireCost"></param>
        /// <param name="moveCost"></param>
        private HexTileAttributesImpl(float fireCost, float moveCost)
        {
            this.fireCost = fireCost;
            this.moveCost = moveCost;
        }

        /// <inheritdoc/>
        float IHexTileAttributes.GetFireCost()
        {
            return this.fireCost;
        }

        /// <inheritdoc/>
        float IHexTileAttributes.GetMoveCost()
        {
            return this.moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private float fireCost = float.MinValue;

            // Todo
            private float moveCost = float.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IHexTileAttributes Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new HexTileAttributesImpl(this.fireCost, this.moveCost);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fireCost"></param>
            /// <returns></returns>
            public Builder SetFireCost(float fireCost)
            {
                this.fireCost = fireCost;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="moveCost"></param>
            /// <returns></returns>
            public Builder SetMoveCost(float moveCost)
            {
                this.moveCost = moveCost;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that fireCost has been set
                if (this.fireCost == float.MinValue)
                {
                    argumentExceptionSet.Add("fireCost has not been set");
                }
                // Check that moveCost has been set
                if (this.moveCost == float.MinValue)
                {
                    argumentExceptionSet.Add("moveCost has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}