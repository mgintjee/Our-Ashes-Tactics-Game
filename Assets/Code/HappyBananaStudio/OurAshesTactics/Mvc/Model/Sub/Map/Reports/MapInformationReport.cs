/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports
{
    /// <summary>
    /// Report used to describe the Map
    /// </summary>
    public class MapInformationReport
    {
        #region Private Fields

        // Todo
        private readonly HashSet<HexTileInformationReport> hexTileInformationReportSet = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileInformationReportSet"></param>
        private MapInformationReport(HashSet<HexTileInformationReport> hexTileInformationReportSet)
        {
            this.hexTileInformationReportSet = new HashSet<HexTileInformationReport>(hexTileInformationReportSet);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<HexTileInformationReport> GetHexTileInformationReportSet()
        {
            return new HashSet<HexTileInformationReport>(this.hexTileInformationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "\n\t>hexTileInformationReportSet:[" +
                "\n\t>" + string.Join("\n\t>", this.GetHexTileInformationReportSet()) +
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
            private HashSet<HexTileInformationReport> hexTileInformationReportSet = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public MapInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MapInformationReport(this.hexTileInformationReportSet);
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
            /// <param name="hexTileInformationReportSet"></param>
            /// <returns></returns>
            public Builder SetHexTileInformationReportSet(HashSet<HexTileInformationReport> hexTileInformationReportSet)
            {
                this.hexTileInformationReportSet = hexTileInformationReportSet;
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
                // Check that hexTileInformationReportSet has been set
                if (this.hexTileInformationReportSet == null)
                {
                    argumentExceptionSet.Add("hexTileInformationReportSet has not been set");
                }
                // Check that cubeCoordinatesHexTileAttributesDictionary is valid
                if (this.hexTileInformationReportSet != null &&
                    this.hexTileInformationReportSet.Count == 0)
                {
                    argumentExceptionSet.Add("hexTileInformationReportSet is invalid");
                }

                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}