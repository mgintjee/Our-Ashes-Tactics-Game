namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// HexTile Object Impl
    /// </summary>
    public class HexTileObjectImpl
        : IHexTileObject
    {
        // Todo
        private readonly ICubeCoordinates cubeCoordinates;

        // Todo
        private readonly HexTileType hexTileType;

        // Todo
        private TalonCallSign talonCallSign;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <param name="hexTileType"></param>
        private HexTileObjectImpl(ICubeCoordinates cubeCoordinates, HexTileType hexTileType)
        {
            this.cubeCoordinates = cubeCoordinates;
            this.hexTileType = hexTileType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileObject"></param>
        private HexTileObjectImpl(IHexTileObject hexTileObject)
        {
            IHexTileReport hexTileReport = hexTileObject.GetHexTileReport();
            this.cubeCoordinates = hexTileReport.GetCubeCoordinates();
            this.hexTileType = hexTileReport.GetHexTileType();
            this.talonCallSign = hexTileReport.GetTalonCallSign();
        }

        /// <inheritdoc/>
        void IHexTileObject.ClearTalonCallSign()
        {
            this.talonCallSign = TalonCallSign.None;
        }

        /// <inheritdoc/>
        IHexTileReport IHexTileObject.GetHexTileReport()
        {
            return new HexTileReportImpl.Builder()
                .SetCubeCoordinates(this.cubeCoordinates)
                .SetHexTileType(this.hexTileType)
                .SetTalonCallSign(this.talonCallSign)
                .Build();
        }

        /// <inheritdoc/>
        void IHexTileObject.SetTalonCallSign(TalonCallSign talonCallSign)
        {
            if (this.talonCallSign.Equals(TalonCallSign.None))
            {
                this.talonCallSign = talonCallSign;
            }
            else
            {
                // Throw an error
            }
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

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IHexTileObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new HexTileObjectImpl(this.cubeCoordinates, this.hexTileType);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hexTileObject"></param>
            /// <returns></returns>
            public IHexTileObject Build(IHexTileObject hexTileObject)
            { return new HexTileObjectImpl(hexTileObject); }

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