/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports

{
    /// <summary>
    /// Report used to describe the Roster
    /// </summary>
    public class RosterInformationReport
    {
        #region Private Fields
        // Todo: Have a map of the identification and the information reports
        // Todo
        private readonly HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet = null;

        // Todo
        private readonly HashSet<TalonIdentificationReport> totalTalonIdentificationReportSet = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeTalonIdentificationReportSet"></param>
        /// <param name="totalTalonIdentificationReportSet"> </param>
        private RosterInformationReport(HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet,
            HashSet<TalonIdentificationReport> totalTalonIdentificationReportSet)
        {
            this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
            this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            return this.activeTalonIdentificationReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetTotalTalonIdentificationReportSet()
        {
            return this.totalTalonIdentificationReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "\n\t>activeTalonIdentificationReportSet:[" +
                "\n\t>" + string.Join("\n\t>", this.GetActiveTalonIdentificationReportSet()) +
                "\n]" +
                "\n\t>totalTalonIdentificationReportSet:[" +
                "\n\t>" + string.Join("\n\t>", this.GetTotalTalonIdentificationReportSet()) +
                "\n]";
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
            private HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet = null;

            // Todo
            private HashSet<TalonIdentificationReport> totalTalonIdentificationReportSet = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public RosterInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterInformationReport(this.activeTalonIdentificationReportSet,
                        this.totalTalonIdentificationReportSet);
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
            /// <param name="activeTalonIdentificationReportSet"></param>
            /// <returns></returns>
            public Builder SetActiveTalonIdentificationReportSet(HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet)
            {
                this.activeTalonIdentificationReportSet = activeTalonIdentificationReportSet;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="totalTalonIdentificationReportSet"></param>
            /// <returns></returns>
            public Builder SetTotalTalonIdentificationReportSet(HashSet<TalonIdentificationReport> totalTalonIdentificationReportSet)
            {
                this.totalTalonIdentificationReportSet = totalTalonIdentificationReportSet;
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
                // Check that activeTalonIdentificationReportSet has been set
                if (this.activeTalonIdentificationReportSet == null)
                {
                    argumentExceptionSet.Add("activeTalonIdentificationReportSet has not been set");
                }
                else
                {
                    // Check that the activeTalonIdentificationReportSet is valid
                    if (this.activeTalonIdentificationReportSet.Count < 2)
                    {
                        argumentExceptionSet.Add("activeTalonIdentificationReportSet is invalid. Count=" +
                            this.activeTalonIdentificationReportSet.Count);
                    }
                }
                // Check that totalTalonIdentificationReportSet has been set
                if (this.totalTalonIdentificationReportSet == null)
                {
                    argumentExceptionSet.Add("totalTalonIdentificationReportSet has not been set");
                }
                else
                {
                    // Check that the totalTalonIdentificationReportSet is valid
                    if (this.totalTalonIdentificationReportSet.Count < 2)
                    {
                        argumentExceptionSet.Add("totalTalonIdentificationReportSet is invalid. Count=" +
                            this.totalTalonIdentificationReportSet.Count);
                    }
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}