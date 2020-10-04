/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Attributes.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileAttributesImpl
        : IHexTileAttributes
    {
        // Todo
        private readonly int fireCost;

        // Todo
        private readonly int moveCost;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fireCost">
        /// </param>
        /// <param name="moveCost">
        /// </param>
        private HexTileAttributesImpl(int fireCost, int moveCost)
        {
            this.fireCost = fireCost;
            this.moveCost = moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetFireCost()
        {
            return this.fireCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetMoveCost()
        {
            return this.moveCost;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": fireCost = " + this.GetFireCost() +
                ", moveCost = " + this.GetMoveCost();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int fireCost;

            // Todo
            private int moveCost;

            // Todo
            private bool setFireCost = false;

            // Todo
            private bool setMoveCost = false;

            /// <summary>
            /// Build the HexTileAttributes with the set parameters
            /// </summary>
            /// <returns>
            /// The IHexTileAttributes
            /// </returns>
            public IHexTileAttributes Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HexTileAttributesImpl(this.fireCost, this.moveCost);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the fireCost
            /// </summary>
            /// <param name="fireCost">
            /// The fireCost to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetFireCost(int fireCost)
            {
                this.fireCost = fireCost;
                this.setFireCost = true;
                return this;
            }

            /// <summary>
            /// Set the value of the moveCost
            /// </summary>
            /// <param name="moveCost">
            /// The moveCost to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMoveCost(int moveCost)
            {
                this.moveCost = moveCost;
                this.setMoveCost = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that fireCost has been set
                if (!this.setFireCost)
                {
                    argumentExceptionSet.Add("fireCost has not been set");
                }
                // Check that moveCost has been set
                if (!this.setMoveCost)
                {
                    argumentExceptionSet.Add("moveCost has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}