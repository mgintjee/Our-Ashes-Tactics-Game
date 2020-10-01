/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileInformationReportImpl
        : IHexTileInformationReport
    {
        // Todo
        private readonly IHexTileAttributes hexTileAttributes;

        // Todo
        private readonly IHexTileConstructionReport hexTileConstructionReport;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileAttributes">
        /// </param>
        /// <param name="hexTileConstructionReport">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        public HexTileInformationReportImpl(IHexTileAttributes hexTileAttributes, IHexTileConstructionReport hexTileConstructionReport, ITalonIdentificationReport talonIdentificationReport)
        {
            this.hexTileAttributes = hexTileAttributes;
            this.hexTileConstructionReport = hexTileConstructionReport;
            this.talonIdentificationReport = talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHexTileAttributes GetHexTileAttributes()
        {
            return this.hexTileAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IHexTileConstructionReport GetHexTileConstructionReport()
        {
            return this.hexTileConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetHexTileAttributes() +
                "\n\t>" + this.GetHexTileConstructionReport() +
                "\n\t>Occupying=" + ((this.GetTalonIdentificationReport() != null)
                    ? this.GetTalonIdentificationReport().ToString()
                    : "empty");
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IHexTileAttributes hexTileAttributes = null;

            // Todo
            private IHexTileConstructionReport hexTileConstructionReport;

            // Todo
            private ITalonIdentificationReport talonIdentificationReport = null;

            /// <summary>
            /// Build the HexTileInformationReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IHexTileInformationReport
            /// </returns>
            public IHexTileInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HexTileInformationReportImpl(this.hexTileAttributes,
                        this.hexTileConstructionReport, this.talonIdentificationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the IHexTileAttributes
            /// </summary>
            /// <param name="hexTileAttributes">
            /// The IHexTileAttributes to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHexTileAttributes(IHexTileAttributes hexTileAttributes)
            {
                this.hexTileAttributes = hexTileAttributes;
                return this;
            }

            /// <summary>
            /// Set the value of the IHexTileConstructionReport
            /// </summary>
            /// <param name="hexTileConstructionReport">
            /// The IHexTileConstructionReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHexTileConstructionReport(IHexTileConstructionReport hexTileConstructionReport)
            {
                this.hexTileConstructionReport = hexTileConstructionReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="talonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
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
                // Check that hexTileAttributes has been set
                if (this.hexTileAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(IHexTileAttributes).Name + " has not been set");
                }
                // Check that hexTileConstructionReport has been set
                if (this.hexTileConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IHexTileConstructionReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}