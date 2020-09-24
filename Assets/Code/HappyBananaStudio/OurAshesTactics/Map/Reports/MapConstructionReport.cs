/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports
{
    /// <summary>
    /// Report used to generate the Map
    /// </summary>
    public class MapConstructionReport

    {
        #region Private Fields

        // Todo
        private readonly bool mapMirrored = false;

        // Todo
        private readonly int mapRadius = int.MinValue;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapRadius">  </param>
        /// <param name="mapMirrored"></param>
        private MapConstructionReport(int mapRadius, bool mapMirrored)
        {
            this.mapRadius = mapRadius;
            this.mapMirrored = mapMirrored;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public bool GetMapMirrored()
        {
            return this.mapMirrored;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        public int GetMapRadius()
        {
            return this.mapRadius;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                ",\n\t>mapRadius: " + this.GetMapRadius() +
                ",\n\t>mapMirrored: " + this.GetMapMirrored();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Todo
            private bool mapMirrored;

            // Todo
            private int mapRadius = -1;

            // Todo
            private bool setMapMirrored = false;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public MapConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MapConstructionReport(this.mapRadius, this.mapMirrored);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapMirrored"></param>
            /// <returns></returns>
            public Builder SetMapMirrored(bool mapMirrored)
            {
                this.mapMirrored = mapMirrored;
                this.setMapMirrored = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapRadius"></param>
            /// <returns></returns>
            public Builder SetMapRadius(int mapRadius)
            {
                this.mapRadius = mapRadius;
                return this;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private HashSet<string> IsValid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that mapMirrored has been set
                if (!this.setMapMirrored)
                {
                    argumentExceptionSet.Add("mapMirrored has not been set");
                }
                // Check that mapSeed is valid
                if (this.mapRadius < 2)
                {
                    argumentExceptionSet.Add("mapRadius= " + this.mapRadius + " is invalid");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}