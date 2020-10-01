/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Action
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionOrderReportImpl
        : ITalonActionOrderReport
    {
        // Todo
        private readonly ITalonIdentificationReport actingTalonIdentificationReport;

        // Todo
        private readonly ActionTypeEnum actionType;

        // Todo
        private readonly IPathObject pathObject;

        // Todo
        private readonly ITalonIdentificationReport targetTalonIdentificationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="actionType">
        /// </param>
        /// <param name="actingTalonIdentificationReport">
        /// </param>
        private TalonActionOrderReportImpl(IPathObject pathObject, ActionTypeEnum actionType,
            ITalonIdentificationReport actingTalonIdentificationReport)
        {
            this.pathObject = pathObject;
            this.actionType = actionType;
            this.actingTalonIdentificationReport = actingTalonIdentificationReport;
            this.targetTalonIdentificationReport = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="actionType">
        /// </param>
        /// <param name="actingTalonIdentificationReport">
        /// </param>
        /// <param name="targetTalonIdentificationReport">
        /// </param>
        private TalonActionOrderReportImpl(IPathObject pathObject, ActionTypeEnum actionType,
            ITalonIdentificationReport actingTalonIdentificationReport, ITalonIdentificationReport targetTalonIdentificationReport)
        {
            this.pathObject = pathObject;
            this.actionType = actionType;
            this.actingTalonIdentificationReport = actingTalonIdentificationReport;
            this.targetTalonIdentificationReport = targetTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonIdentificationReport GetActingTalonIdentificationReport()
        {
            return this.actingTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionTypeEnum GetActionType()
        {
            return this.actionType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IPathObject GetPathObject()
        {
            return this.pathObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonIdentificationReport GetTargetTalonIdentificationReport()
        {
            return this.targetTalonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetPathObject() +
                "\n\t>" + this.GetActionType() +
                "\n\t>Acting " + this.GetActingTalonIdentificationReport() +
                ((this.GetTargetTalonIdentificationReport() != null)
                ? "\n\t>Target " + this.GetTargetTalonIdentificationReport()
                : "");
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonIdentificationReport actingTalonIdentificationReport = null;

            // Todo
            private ActionTypeEnum actionType = ActionTypeEnum.None;

            // Todo
            private IPathObject pathObject = null;

            // Todo
            private ITalonIdentificationReport targetTalonIdentificationReport = null;

            /// <summary>
            /// Build the TalonActionOrderReport with the set parameters
            /// </summary>
            /// <returns>
            /// The ITalonActionOrderReport
            /// </returns>
            public ITalonActionOrderReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.targetTalonIdentificationReport != null)
                    {
                        // Instantiate a new Report
                        return new TalonActionOrderReportImpl(this.pathObject, this.actionType,
                            this.actingTalonIdentificationReport, this.targetTalonIdentificationReport);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new TalonActionOrderReportImpl(this.pathObject, this.actionType,
                            this.actingTalonIdentificationReport);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="actingTalonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActingTalonIdentificationReport(ITalonIdentificationReport actingTalonIdentificationReport)
            {
                this.actingTalonIdentificationReport = actingTalonIdentificationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ActionTypeEnum
            /// </summary>
            /// <param name="actionType">
            /// The ActionTypeEnum to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActionType(ActionTypeEnum actionType)
            {
                this.actionType = actionType;
                return this;
            }

            /// <summary>
            /// Set the value of the IPathObject
            /// </summary>
            /// <param name="pathObject">
            /// The IPathObject to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPathObject(IPathObject pathObject)
            {
                this.pathObject = pathObject;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonIdentificationReport
            /// </summary>
            /// <param name="targetTalonIdentificationReport">
            /// The ITalonIdentificationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTargetTalonIdentificationReport(ITalonIdentificationReport targetTalonIdentificationReport)
            {
                this.targetTalonIdentificationReport = targetTalonIdentificationReport;
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
                // Check that pathObject has been set
                if (this.pathObject == null)
                {
                    argumentExceptionSet.Add(typeof(IPathObject).Name + " has not been set");
                }
                // Check that actionType has been set
                if (this.actionType == ActionTypeEnum.None)
                {
                    argumentExceptionSet.Add(typeof(ActionTypeEnum).Name + " has not been set");
                }
                // Check that the target
                else if (this.actionType == ActionTypeEnum.Fire)
                {
                    // Check that targetTalonIdentificationReport has been set
                    if (this.targetTalonIdentificationReport == null)
                    {
                        argumentExceptionSet.Add("Target " + typeof(ITalonIdentificationReport).Name + " has not been set");
                    }
                }
                // Check that actingTalonIdentificationReport has been set
                if (this.actingTalonIdentificationReport == null)
                {
                    argumentExceptionSet.Add("Acting " + typeof(ITalonIdentificationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}