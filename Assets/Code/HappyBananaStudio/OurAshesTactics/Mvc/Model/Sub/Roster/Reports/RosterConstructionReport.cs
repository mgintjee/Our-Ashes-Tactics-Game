/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports
{
    /// <summary>
    /// Report used to generate the Roster
    /// </summary>
    public class RosterConstructionReport
    {
        #region Private Fields

        // Determines the information required for constructing Talons
        private readonly HashSet<TalonConstructionReport> talonConstructionReportSet;

        // Determines which controller is responsible for a phalanx
        private readonly Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary;

        // Determines which Faction a phalanx is fighting for
        private readonly Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReportSet">             </param>
        /// <param name="talonControllerIdPhalanxIdSetDictionary"></param>
        /// <param name="talonFactionIdPhalanxIdSetDictionary">   </param>
        private RosterConstructionReport(HashSet<TalonConstructionReport> talonConstructionReportSet,
            Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary,
            Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary)
        {
            this.talonConstructionReportSet = talonConstructionReportSet;
            this.talonControllerIdPhalanxIdSetDictionary = talonControllerIdPhalanxIdSetDictionary;
            this.talonFactionIdPhalanxIdSetDictionary = talonFactionIdPhalanxIdSetDictionary;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonConstructionReport> GetTalonConstructionReportSet()
        {
            return this.talonConstructionReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> GetTalonControllerPhalanxSetDictionary()
        {
            return this.talonControllerIdPhalanxIdSetDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> GetTalonFactionPhalanxSetDictionary()
        {
            return this.talonFactionIdPhalanxIdSetDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string talonConstructionReportSetString = string.Join("\n\t>", this.GetTalonConstructionReportSet());
            string talonControllerIdPhalanxIdSetDictionaryString = "";
            string talonFactionIdPhalanxIdSetDictionaryString = "";

            foreach (TalonControllerIdEnum talonControllerId in this.GetTalonControllerPhalanxSetDictionary().Keys)
            {
                talonControllerIdPhalanxIdSetDictionaryString += "\n\t>" + talonControllerId + ":" +
                    string.Join("\n\t>", this.GetTalonControllerPhalanxSetDictionary()[talonControllerId]);
            }
            foreach (TalonFactionIdEnum talonFactionId in this.GetTalonFactionPhalanxSetDictionary().Keys)
            {
                talonFactionIdPhalanxIdSetDictionaryString += "\n\t>" + talonFactionId + ":" +
                    string.Join("\n\t>", this.GetTalonFactionPhalanxSetDictionary()[talonFactionId]);
            }

            return this.GetType() + ": " +
                "\n\t>talonConstructionReportSet: " + talonConstructionReportSetString +
                ",\n\t>talonControllerIdPhalanxIdSetDictionary: " + talonControllerIdPhalanxIdSetDictionaryString +
                ",\n\t>talonFactionIdPhalanxIdSetDictionary: " + talonFactionIdPhalanxIdSetDictionaryString;
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Determines the information required for constructing Talons
            private HashSet<TalonConstructionReport> talonConstructionReportSet;

            // Determines which controller is responsible for a phalanx
            private Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary;

            // Determines which Faction a phalanx is fighting for
            private Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public RosterConstructionReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new RosterConstructionReport(this.talonConstructionReportSet,
                        this.talonControllerIdPhalanxIdSetDictionary, this.talonFactionIdPhalanxIdSetDictionary);
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
            /// <param name="talonConstructionReportSet"></param>
            /// <returns></returns>
            public Builder SetTalonConstructionReportSet(
                HashSet<TalonConstructionReport> talonConstructionReportSet)
            {
                this.talonConstructionReportSet = talonConstructionReportSet;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonControllerIdPhalanxIdSetDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonControllerIdPhalanxIdSetDictionary(
                Dictionary<TalonControllerIdEnum, HashSet<TalonPhalanxIdEnum>> talonControllerIdPhalanxIdSetDictionary)
            {
                this.talonControllerIdPhalanxIdSetDictionary = talonControllerIdPhalanxIdSetDictionary;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonFactionIdPhalanxIdSetDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonFactionIdPhalanxIdSetDictionary(Dictionary<TalonFactionIdEnum, HashSet<TalonPhalanxIdEnum>> talonFactionIdPhalanxIdSetDictionary)
            {
                this.talonFactionIdPhalanxIdSetDictionary = talonFactionIdPhalanxIdSetDictionary;
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
                // Check that talonConstructionReportSet has been set
                if (this.talonConstructionReportSet == null)
                {
                    argumentExceptionSet.Add("talonConstructionReportSet has not been set");
                }
                else
                {
                    // Check that the talonConstructionReportSet is valid
                    if (this.talonConstructionReportSet.Count < 2)
                    {
                        argumentExceptionSet.Add("talonConstructionReportSet is invalid. Count=" +
                            this.talonConstructionReportSet.Count);
                    }
                }
                // Check that talonControllerIdPhalanxIdSetDictionary has been set
                if (this.talonControllerIdPhalanxIdSetDictionary == null)
                {
                    argumentExceptionSet.Add("talonControllerIdPhalanxIdSetDictionary has not been set");
                }
                else
                {
                    // Check that the talonControllerIdPhalanxIdSetDictionary is valid
                    if (this.talonControllerIdPhalanxIdSetDictionary.Count < 2)
                    {
                        argumentExceptionSet.Add("talonControllerIdPhalanxIdSetDictionary is invalid. Count=" +
                            this.talonControllerIdPhalanxIdSetDictionary.Count);
                    }
                }
                // Check that talonFactionIdPhalanxIdSetDictionary has been set
                if (this.talonFactionIdPhalanxIdSetDictionary == null)
                {
                    argumentExceptionSet.Add("talonFactionIdPhalanxIdSetDictionary has not been set");
                }
                else
                {
                    // Check that the talonFactionIdPhalanxIdSetDictionary is valid
                    if (this.talonFactionIdPhalanxIdSetDictionary.Count < 2)
                    {
                        argumentExceptionSet.Add("talonFactionIdPhalanxIdSetDictionary is invalid. Count=" +
                            this.talonFactionIdPhalanxIdSetDictionary.Count);
                    }
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}