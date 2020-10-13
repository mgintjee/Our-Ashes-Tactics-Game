/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
using HappyBananaStudio.OurAshes.Tactics.Api.HexTiles.Reports;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.HexTiles.Enums;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.HexTiles
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileConstructionReportImpl
        : IHexTileConstructionReport
    {
        // Todo
        private readonly ICubeCoordinates cubeCoordinates;

        // Todo
        private readonly HexTileTypeEnum hexTileType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <param name="hexTileType">
        /// </param>
        public HexTileConstructionReportImpl(ICubeCoordinates cubeCoordinates, HexTileTypeEnum hexTileType)
        {
            this.cubeCoordinates = cubeCoordinates;
            this.hexTileType = hexTileType;
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
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetCubeCoordinates() +
                "\n\t>" + typeof(HexTileTypeEnum).Name + "=" + this.GetHexTileType();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            // Todo
            private HexTileTypeEnum hexTileType = HexTileTypeEnum.None;

            /// <summary>
            /// Build the HexTileConstructionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IHexTileConstructionReport
            /// </returns>
            public IHexTileConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HexTileConstructionReportImpl(this.cubeCoordinates, this.hexTileType);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the CubeCoordinates
            /// </summary>
            /// <param name="cubeCoordinates">
            /// The CubeCoordinates to set
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
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that cubeCoordinates has been set
                if (this.cubeCoordinates == null)
                {
                    argumentExceptionSet.Add(typeof(ICubeCoordinates).Name + " has not been set");
                }
                // Check that hexTileType has been set
                if (this.hexTileType == HexTileTypeEnum.None)
                {
                    argumentExceptionSet.Add(typeof(HexTileTypeEnum).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
