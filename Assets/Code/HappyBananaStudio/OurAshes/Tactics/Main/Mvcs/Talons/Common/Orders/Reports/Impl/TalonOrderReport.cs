using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Pathing.Objects.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonOrderReport
        : ITalonOrderReport
    {
        // Todo
        private readonly TalonCallSign actingTalonCallSign;

        // Todo
        private readonly OrderType orderType;

        // Todo
        private readonly IPathObject pathObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <param name="actionType"></param>
        /// <param name="pathObject"></param>
        private TalonOrderReport(TalonCallSign talonCallSign, OrderType actionType, IPathObject pathObject)
        {
            this.actingTalonCallSign = talonCallSign;
            this.orderType = actionType;
            this.pathObject = pathObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCallSign ITalonOrderReport.GetActingTalonCallSign()
        {
            return this.actingTalonCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        OrderType ITalonOrderReport.GetOrderType()
        {
            return this.orderType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IPathObject ITalonOrderReport.GetPathObject()
        {
            return this.pathObject;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Acting {1}={2}, {3}={4}, {5}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.actingTalonCallSign,
                typeof(OrderType).Name, this.orderType,
                this.pathObject);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private TalonCallSign actingTalonCallSign = TalonCallSign.None;

            // Todo
            private OrderType actionType = OrderType.None;

            // Todo
            private IPathObject pathObject = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITalonOrderReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonOrderReport(this.actingTalonCallSign, this.actionType, this.pathObject);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionType"></param>
            /// <returns></returns>
            public Builder SetActingTalonCallSign(TalonCallSign actionType)
            {
                this.actingTalonCallSign = actionType;
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