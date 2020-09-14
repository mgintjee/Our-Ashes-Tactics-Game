/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonActionResultReport
    {
        #region Private Fields

        // Todo
        private readonly TalonActionOrderReport talonActionOrder = null;
        // Todo
        private readonly TalonAttributesReport talonAttributesReport = null;

        #endregion Private Fields

        #region Private Constructors
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrder"></param>
        /// <param name="talonAttributesReport"></param>
        private TalonActionResultReport(TalonActionOrderReport talonActionOrder, TalonAttributesReport talonAttributesReport)
        {
            this.talonActionOrder = talonActionOrder;
            this.talonAttributesReport = talonAttributesReport;
        }

        #endregion Private Constructors

        #region Public Methods
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonActionOrderReport GetTalonActionOrder()
        {
            return this.talonActionOrder;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonAttributesReport GetTalonAttributesReport()
        {
            return this.talonAttributesReport;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ": " +
                "\n\t>" + this.GetTalonActionOrder() +
                "\n\t>" + this.GetTalonAttributesReport();
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
            private TalonActionOrderReport talonActionOrder = null;
            // Todo
            private TalonAttributesReport talonAttributesReport = null;

            #endregion Private Fields

            #region Public Methods
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public TalonActionResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonActionResultReport(this.talonActionOrder, this.talonAttributesReport);
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
            /// <param name="talonActionOrder"></param>
            /// <returns></returns>
            public Builder SetTalonActionOrder(TalonActionOrderReport talonActionOrder)
            {
                this.talonActionOrder = talonActionOrder;
                return this;
            }
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonAttributesReport"></param>
            /// <returns></returns>
            public Builder SetTalonAttributesReport(TalonAttributesReport talonAttributesReport)
            {
                this.talonAttributesReport = talonAttributesReport;
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
                // Check that talonActionOrder has been set
                if (this.talonActionOrder == null)
                {
                    argumentExceptionSet.Add(typeof(TalonActionOrderReport) + " has not been set");
                }
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonAttributesReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}