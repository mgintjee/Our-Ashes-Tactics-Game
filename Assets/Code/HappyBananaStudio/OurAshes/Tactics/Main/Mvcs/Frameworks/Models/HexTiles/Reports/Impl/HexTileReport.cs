namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct HexTileReport
        : IHexTileReport
    {
        // Todo
        private readonly ICubeCoordinates cubeCoordinates;

        // Todo
        private readonly HexTileType hexTileType;

        // Todo
        private readonly TalonCallSign talonCallSign;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="hexTileType"></param>
        /// <param name="talonCallSign"></param>
        private HexTileReport(ICubeCoordinates cubeCoordinates,
            HexTileType hexTileType, TalonCallSign talonCallSign)
        {
            this.cubeCoordinates = cubeCoordinates;
            this.hexTileType = hexTileType;
            this.talonCallSign = talonCallSign;
        }

        /// <inheritdoc/>
        ICubeCoordinates IHexTileReport.GetCubeCoordinates()
        {
            return this.cubeCoordinates;
        }

        /// <inheritdoc/>
        HexTileType IHexTileReport.GetHexTileType()
        {
            return this.hexTileType;
        }

        /// <inheritdoc/>
        TalonCallSign IHexTileReport.GetTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}={3}, {4}={5}",
                this.GetType().Name, this.cubeCoordinates, typeof(HexTileType).Name,
                this.hexTileType, typeof(TalonCallSign).Name, this.talonCallSign);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICubeCoordinates cubeCoordinates = null;

            // Todo
            private HexTileType hexTileType = HexTileType.None;

            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IHexTileReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new HexTileReport(this.cubeCoordinates, this.hexTileType, this.talonCallSign);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="cubeCoordinates"></param>
            /// <returns></returns>
            public Builder SetCubeCoordinates(ICubeCoordinates cubeCoordinates)
            {
                this.cubeCoordinates = cubeCoordinates;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hexTileType"></param>
            /// <returns></returns>
            public Builder SetHexTileType(HexTileType hexTileType)
            {
                this.hexTileType = hexTileType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
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
                    argumentExceptionSet.Add(typeof(ICubeCoordinates) + " has not been set");
                }
                // Check that hexTileType has been set
                if (this.hexTileType == HexTileType.None)
                {
                    argumentExceptionSet.Add(typeof(HexTileType) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}