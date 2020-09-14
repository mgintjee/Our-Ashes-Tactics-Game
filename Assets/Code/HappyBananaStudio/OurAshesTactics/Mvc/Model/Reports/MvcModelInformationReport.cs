/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Reports
{
    /// <summary>
    /// Report used to describe the MvcModel
    /// </summary>
    public class MvcModelInformationReport
    {
        #region Private Fields

        //Todo
        private readonly MapInformationReport mapInformationReport = null;

        //Todo
        private readonly RosterInformationReport rosterInformationReport = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mapInformationReport">   </param>
        /// <param name="rosterInformationReport"></param>
        private MvcModelInformationReport(MapInformationReport mapInformationReport,
            RosterInformationReport rosterInformationReport)
        {
            this.mapInformationReport = mapInformationReport;
            this.rosterInformationReport = rosterInformationReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapInformationReport GetMapInformationReport()
        {
            return this.mapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public RosterInformationReport GetRosterInformationReport()
        {
            return this.rosterInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n\t>" + this.GetMapInformationReport() +
                "\n\t>:" + this.GetRosterInformationReport();
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
            private MapInformationReport mapInformationReport = null;

            //Todo
            private RosterInformationReport rosterInformationReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public MvcModelInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MvcModelInformationReport(this.mapInformationReport, this.rosterInformationReport);
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
            /// <param name="mapInformationReport"></param>
            /// <returns></returns>
            public Builder SetMapInformationReport(MapInformationReport mapInformationReport)
            {
                this.mapInformationReport = mapInformationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rosterInformationReport"></param>
            /// <returns></returns>
            public Builder SetRosterInformationReport(RosterInformationReport rosterInformationReport)
            {
                this.rosterInformationReport = rosterInformationReport;
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
                // Check that mapInformationReport has been set
                if (this.mapInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(MapInformationReport) + " has not been set");
                }
                // Check that rosterInformationReport has been set
                if (this.rosterInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(RosterInformationReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}