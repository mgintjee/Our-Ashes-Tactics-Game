/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Maps.Game
{
    /// <summary>
    /// Report used to generate the Map
    /// </summary>
    public struct GameMapConstructionReportImpl
        : IGameMapConstructionReport

    {
        // Todo
        private readonly HashSet<ICubeCoordinates> cubeCoordiantesSet;

        // Todo
        private readonly bool isGameMapMirrored;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinatesSet">
        /// </param>
        /// <param name="isGameMapMirrored">
        /// </param>
        private GameMapConstructionReportImpl(HashSet<ICubeCoordinates> cubeCoordinatesSet, bool isGameMapMirrored)
        {
            this.cubeCoordiantesSet = cubeCoordinatesSet;
            this.isGameMapMirrored = isGameMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ICubeCoordinates> GetCubeCoordinatesSet()
        {
            return this.cubeCoordiantesSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool GetIsGameMapMirrored()
        {
            return this.isGameMapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                "\n\t>IsGameMapMirrored: " + this.GetIsGameMapMirrored() +
                "\n\t> Set:" + typeof(ICubeCoordinates).Name + ":[\n\t>" +
                string.Join("\n\t\t>", this.GetCubeCoordinatesSet())
                + "\n]";
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private HashSet<ICubeCoordinates> cubeCoordiantesSet = null;

            // Todo
            private bool isGameMapMirrored;

            // Todo
            private bool setIsGameMapMirrored = false;

            /// <summary>
            /// Build the GameMapConstructionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IGameMapConstructionReport
            /// </returns>
            public IGameMapConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new GameMapConstructionReportImpl(this.cubeCoordiantesSet, this.isGameMapMirrored);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapRadius">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetCubeCoordinatesSet(HashSet<ICubeCoordinates> cubeCoordiantesSet)
            {
                this.cubeCoordiantesSet = new HashSet<ICubeCoordinates>(cubeCoordiantesSet);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapMirrored">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetMapMirrored(bool mapMirrored)
            {
                this.isGameMapMirrored = mapMirrored;
                this.setIsGameMapMirrored = true;
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
                // Check that isGameMapMirrored has been set
                if (!this.setIsGameMapMirrored)
                {
                    argumentExceptionSet.Add("isGameMapMirrored has not been set");
                }
                // Check that gameMapRadius has been set
                if (this.cubeCoordiantesSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ICubeCoordinates).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}