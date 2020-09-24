/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports
{
    /// <summary>
    /// Report to display the all of the information for a specific HexTile
    /// </summary>
    public class HexTileInformationReport
    {
        #region Private Fields

        // Todo
        private readonly HexTileAttributes hexTileAttributes = null;

        // Todo
        private readonly HexTileConstructionReport hexTileConstructionReport = null;

        // Todo
        private readonly TalonIdentificationReport talonIdentificationReport = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileAttributes">        </param>
        /// <param name="tileConstructionReport">   </param>
        /// <param name="talonIdentificationReport"></param>
        private HexTileInformationReport(HexTileAttributes hexTileAttributes, HexTileConstructionReport tileConstructionReport,
            TalonIdentificationReport talonIdentificationReport)
        {
            this.hexTileAttributes = hexTileAttributes;
            this.hexTileConstructionReport = tileConstructionReport;
            this.talonIdentificationReport = talonIdentificationReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HexTileAttributes GetHexTileAttributes()
        {
            return this.hexTileAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HexTileConstructionReport GetHexTileConstructionReport()
        {
            return this.hexTileConstructionReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n\t>" + this.GetHexTileAttributes() +
                "\n\t>" + ((this.GetTalonIdentificationReport() != null)
                    ? this.GetTalonIdentificationReport().ToString()
                    : "Empty");
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
            private HexTileAttributes hexTileAttributes = null;

            // Todo
            private HexTileConstructionReport hexTileConstructionReport = null;

            // Todo
            private TalonIdentificationReport talonIdentificationReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public HexTileInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new HexTileInformationReport(this.hexTileAttributes, this.hexTileConstructionReport, talonIdentificationReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n\t>", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="hexTileAttributes"></param>
            /// <returns></returns>
            public Builder SetHexTileAttributes(HexTileAttributes hexTileAttributes)
            {
                this.hexTileAttributes = hexTileAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="tileConstructionReport"></param>
            /// <returns></returns>
            public Builder SetHexTileConstructionReport(HexTileConstructionReport tileConstructionReport)
            {
                this.hexTileConstructionReport = tileConstructionReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonIdentificationReport"></param>
            /// <returns></returns>
            public Builder SetTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
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
                // Check that hexTileAttributes has been set
                if (this.hexTileAttributes == null)
                {
                    argumentExceptionSet.Add(typeof(HexTileAttributes) + " has not been set");
                }
                // Check that hexTileConstructionReport has been set
                if (this.hexTileConstructionReport == null)
                {
                    argumentExceptionSet.Add(typeof(HexTileConstructionReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}