/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Api;
using HappyBananaStudio.OurAshesTactics.Pathing.Object.Impl;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonActionOrderReport
    {
        #region Private Fields

        // Todo
        private readonly TalonIdentificationReport actingTalonIdentificationReport = null;

        // Todo
        private readonly TalonActionTypeEnum actionType = TalonActionTypeEnum.NULL;

        // Todo
        private readonly IPathObject pathObject = null;

        // Todo
        private readonly TalonIdentificationReport targetTalonIdentificationReport = null;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actingTalonIdentificationReport"></param>
        /// <param name="targetTalonIdentificationReport"></param>
        /// <param name="pathObject">                     </param>
        public TalonActionOrderReport(TalonIdentificationReport actingTalonIdentificationReport,
            TalonIdentificationReport targetTalonIdentificationReport, IPathObject pathObject)
        {
            this.actingTalonIdentificationReport = actingTalonIdentificationReport;
            this.pathObject = pathObject;
            if (this.pathObject is PathObjectMove)
            {
                this.actionType = TalonActionTypeEnum.Move;
            }
            else if (this.pathObject is PathObjectFire)
            {
                this.actionType = TalonActionTypeEnum.Fire;
                this.targetTalonIdentificationReport = targetTalonIdentificationReport;
            }
            else if (this.pathObject is PathObjectWait)
            {
                this.actionType = TalonActionTypeEnum.Wait;
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport GetActingTalonIdentificationReport()
        {
            return this.actingTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public IPathObject GetPathObject()
        {
            return this.pathObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonActionTypeEnum GetTalonActionType()
        {
            return this.actionType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport GetTargetTalonIdentificationReport()
        {
            return this.targetTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string targetTalonIdentificationReportString = (this.GetTargetTalonIdentificationReport() != null)
                ? "\n\t>Target " + this.GetTargetTalonIdentificationReport()
                : "";
            return this.GetType().Name + ": " +
                "\n\t>Acting " + this.GetActingTalonIdentificationReport() +
                "\n\t>" + typeof(TalonActionTypeEnum) + ": " + this.GetTalonActionType() +
                "\n\t>" + typeof(IPathObject) + ": [" + this.GetPathObject() + "]" +
                targetTalonIdentificationReportString;
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo

            #region Private Fields

            private TalonIdentificationReport actingTalonIdentificationReport = null;

            // Todo
            private IPathObject pathObject = null;

            // Todo
            private TalonIdentificationReport targetTalonIdentificationReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public TalonActionOrderReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonActionOrderReport(this.actingTalonIdentificationReport, this.targetTalonIdentificationReport, this.pathObject);
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
            /// <param name="actingTalonIdentificationReport"></param>
            /// <returns></returns>
            public Builder SetActingTalonIdentificationReport(TalonIdentificationReport actingTalonIdentificationReport)
            {
                this.actingTalonIdentificationReport = actingTalonIdentificationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="pathObject"></param>
            /// <returns></returns>
            public Builder SetPathObject(IPathObject pathObject)
            {
                this.pathObject = pathObject;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="targetTalonIdentificationReport"></param>
            /// <returns></returns>
            public Builder SetTargetTalonIdentificationReport(TalonIdentificationReport targetTalonIdentificationReport)
            {
                this.targetTalonIdentificationReport = targetTalonIdentificationReport;
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
                // Check that pathObject has been set
                if (this.pathObject == null)
                {
                    argumentExceptionSet.Add(typeof(IPathObject) + " has not been set");
                }
                // Check that actingTalonIdentificationReport has been set
                if (this.actingTalonIdentificationReport == null)
                {
                    argumentExceptionSet.Add("Acting " + typeof(TalonIdentificationReport) + " has not been set");
                }
                // Check that actingTalonIdentificationReport has been set if this is a PathObjectFire
                if (this.pathObject is PathObjectFire &&
                    this.targetTalonIdentificationReport == null)
                {
                    argumentExceptionSet.Add("Target " + typeof(TalonIdentificationReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}