/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Initializer.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcInitializationReport
    {
        #region Private Fields

        private readonly int gameSeed;

        // Determines the dimensions of the map
        private readonly MapConstructionReport mapConstructionReport;

        // Determines the dynamics of the roster
        private readonly RosterConstructionReport rosterConstructionReport;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameSeed">                </param>
        /// <param name="mapConstructionReport">   </param>
        /// <param name="rosterConstructionReport"></param>
        private MvcInitializationReport(int gameSeed,
            MapConstructionReport mapConstructionReport,
            RosterConstructionReport rosterConstructionReport)
        {
            this.gameSeed = gameSeed;
            this.mapConstructionReport = mapConstructionReport;
            this.rosterConstructionReport = rosterConstructionReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetGameSeed()
        {
            return this.gameSeed;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapConstructionReport GetMapConstructionReport()
        {
            return this.mapConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public RosterConstructionReport GetRosterConstructionReport()
        {
            return this.rosterConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().ToString();
        }

        #endregion Public Methods

        #region Public Classes

        public class Builder
        {
            #region Private Fields

            // Todo
            private int gameSeed = int.MinValue;

            // Todo
            private bool gameSeedSet = false;

            // Determines the dimensions of the map
            private MapConstructionReport mapConstructionReport = null;

            // Determines the dynamics of the roster
            private RosterConstructionReport rosterConstructionReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public MvcInitializationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MvcInitializationReport(this.gameSeed, this.mapConstructionReport, this.rosterConstructionReport);
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
            /// <param name="gameSeed"></param>
            /// <returns></returns>
            public Builder SetGameSeed(int gameSeed)
            {
                this.gameSeed = gameSeed;
                this.gameSeedSet = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapConstructionReport"></param>
            /// <returns></returns>
            public Builder SetMapConstructionReport(MapConstructionReport mapConstructionReport)
            {
                this.mapConstructionReport = mapConstructionReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rosterConstructionReport"></param>
            /// <returns></returns>
            public Builder SetRosterContructionReport(RosterConstructionReport rosterConstructionReport)
            {
                this.rosterConstructionReport = rosterConstructionReport;
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
                // Check if the gameSeed has been set
                if (!this.gameSeedSet)
                {
                    argumentExceptionSet.Add("gameSeed has not been set");
                }
                // Check if the mapConstructionReport has been set
                if (this.mapConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(MapConstructionReport) + " has not been set");
                }
                // Check if the rosterConstructionReport has been set
                if (this.rosterConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(RosterConstructionReport) + " has not been set");
                }

                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}