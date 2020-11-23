namespace HappyBananaStudio.OurAshes.Tactics.Impl.HexTiles.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.HexTiles;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileInformationReportImpl
        : IHexTileInformationReport
    {
        // Todo
        private readonly ICubeCoordinates cubeCoordinates;

        // Todo
        private readonly HexTileTypeEnum hexTileType;

        // Todo
        private readonly ITalonIdentificationReport talonIdentificationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileType">
        /// </param>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="talonIdentificationReport">
        /// </param>
        public HexTileInformationReportImpl(HexTileTypeEnum hexTileType, ICubeCoordinates cubeCoordinates, ITalonIdentificationReport talonIdentificationReport)
        {
            this.hexTileType = hexTileType;
            this.cubeCoordinates = cubeCoordinates;
            this.talonIdentificationReport = talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HexTileTypeEnum GetHexTileType()
        {
            return this.hexTileType;
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
                "\n\t>" + this.GetHexTileType() +
                "\n\t>" + this.GetCubeCoordinates() +
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
            private ICubeCoordinates cubeCoordinates;

            // Todo
            private HexTileTypeEnum hexTileType = HexTileTypeEnum.None;

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
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HexTileInformationReportImpl(this.hexTileType,
                        this.cubeCoordinates, this.talonIdentificationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ICubeCoordinates
            /// </summary>
            /// <param name="cubeCoordinates">
            /// The ICubeCoordinates to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Set the value of the HexTileTypeEnum
            /// </summary>
            /// <param name="hexTileType">
            /// The HexTileTypeEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetHexTileType(HexTileTypeEnum hexTileType)
            {
                this.hexTileType = hexTileType;
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
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that hexTileAttributes has been set
                if (this.hexTileType == HexTileTypeEnum.None)
                {
                    argumentExceptionSet.Add(typeof(IHexTileAttributes).Name + " has not been set");
                }
                // Check that cubeCoordinates has been set
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}