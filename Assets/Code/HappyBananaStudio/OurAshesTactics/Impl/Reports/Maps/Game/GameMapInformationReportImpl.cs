/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Maps.Game
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct GameMapInformationReportImpl
        : IGameMapInformationReport
    {
        // Todo
        private readonly HashSet<IHexTileInformationReport> hexTileInformationReportSet;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileInformationReportSet">
        /// </param>
        private GameMapInformationReportImpl(HashSet<IHexTileInformationReport> hexTileInformationReportSet)
        {
            this.hexTileInformationReportSet = hexTileInformationReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<IHexTileInformationReport> GetHexTileInformationReportSet()
        {
            return new HashSet<IHexTileInformationReport>(this.hexTileInformationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Set: " + typeof(IHexTileInformationReport).Name + "=[" +
                "\n\t\t>" + string.Join("\n\t\t>", this.hexTileInformationReportSet) +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private HashSet<IHexTileInformationReport> hexTileInformationReportSet = null;

            /// <summary>
            /// Build the GameMapInformationReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IGameMapInformationReport
            /// </returns>
            public IGameMapInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new GameMapInformationReportImpl(this.hexTileInformationReportSet);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Set: HexTileInformationReport
            /// </summary>
            /// <param name="hexTileInformationReportSet">
            /// The Set: HexTileInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHexTileInformationReportSet(HashSet<IHexTileInformationReport> hexTileInformationReportSet)
            {
                this.hexTileInformationReportSet = new HashSet<IHexTileInformationReport>(hexTileInformationReportSet);
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
                // Check that hexTileInformationReportSet has been set
                if (this.hexTileInformationReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IHexTileInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}