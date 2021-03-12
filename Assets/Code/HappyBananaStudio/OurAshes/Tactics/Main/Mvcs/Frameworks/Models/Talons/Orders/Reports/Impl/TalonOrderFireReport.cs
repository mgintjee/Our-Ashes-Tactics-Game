namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonOrderFireReport
        : ITalonOrderFireReport
    {
        // Todo
        private readonly TalonCallSign actingTalonCallSign;

        // Todo
        private readonly TalonCallSign targetTalonCallSign;

        // Todo
        private readonly OrderType orderType;

        // Todo
        private readonly IPathObject pathObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="actingTalonCallSign"></param>
        /// <param name="targetTalonCallSign"></param>
        /// <param name="actionType"></param>
        /// <param name="pathObject"></param>
        private TalonOrderFireReport(TalonCallSign actingTalonCallSign, TalonCallSign targetTalonCallSign,
            OrderType actionType, IPathObject pathObject)
        {
            this.actingTalonCallSign = actingTalonCallSign;
            this.targetTalonCallSign = targetTalonCallSign;
            this.orderType = actionType;
            this.pathObject = pathObject;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonOrderReport.GetActingTalonCallSign()
        {
            return this.actingTalonCallSign;
        }

        /// <inheritdoc/>
        OrderType ITalonOrderReport.GetOrderType()
        {
            return this.orderType;
        }

        /// <inheritdoc/>
        IPathObject ITalonOrderReport.GetPathObject()
        {
            return this.pathObject;
        }

        /// <inheritdoc/>
        TalonCallSign ITalonOrderFireReport.GetTargetTalonCallSign()
        {
            return this.targetTalonCallSign;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Acting {1}={2}, Target {3}={4}, {5}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.actingTalonCallSign,
                typeof(TalonCallSign).Name, this.targetTalonCallSign, this.pathObject);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign actingTalonCallSign = TalonCallSign.None;

            // Todo
            private TalonCallSign targetTalonCallSign = TalonCallSign.None;

            // Todo
            private OrderType actionType = OrderType.None;

            // Todo
            private IPathObject pathObject = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonOrderFireReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonOrderFireReport(this.actingTalonCallSign,
                        this.targetTalonCallSign, this.actionType, this.pathObject);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actingTalonCallSign"></param>
            /// <returns></returns>
            public Builder SetActingTalonCallSign(TalonCallSign actingTalonCallSign)
            {
                this.actingTalonCallSign = actingTalonCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="targetTalonCallSign"></param>
            /// <returns></returns>
            public Builder SetTargetTalonCallSign(TalonCallSign targetTalonCallSign)
            {
                this.targetTalonCallSign = targetTalonCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionType"></param>
            /// <returns></returns>
            public Builder SetActionType(OrderType actionType)
            {
                this.actionType = actionType;
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
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that actingTalonCallSign has been set
                if (this.actingTalonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add("Acting " + typeof(TalonCallSign) + " has not been set");
                }
                // Check that targetTalonCallSign has been set
                if (this.targetTalonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add("Target " + typeof(TalonCallSign) + " has not been set");
                }
                // Check that actionType has been set
                if (this.actionType == OrderType.None)
                {
                    argumentExceptionSet.Add(typeof(OrderType) + " has not been set");
                }
                // Check that pathObject has been set
                if (this.pathObject == null)
                {
                    argumentExceptionSet.Add(typeof(IPathObject) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}