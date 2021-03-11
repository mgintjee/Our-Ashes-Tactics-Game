namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TurnOrderReport
        : ITurnOrderReport
    {
        // Todo
        private readonly IList<TalonCallSign> orderedTalonCallSignList;

        // Todo
        private readonly int phaseCount;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phaseCount"></param>
        /// <param name="orderedTalonCallSignList"></param>
        private TurnOrderReport(int phaseCount, IList<TalonCallSign> orderedTalonCallSignList)
        {
            this.phaseCount = phaseCount;
            this.orderedTalonCallSignList = new List<TalonCallSign>(orderedTalonCallSignList);
        }

        /// <inheritdoc/>
        IList<TalonCallSign> ITurnOrderReport.GetOrderedTalonCallSignList()
        {
            return new List<TalonCallSign>(this.orderedTalonCallSignList);
        }

        /// <inheritdoc/>
        int ITurnOrderReport.GetPhaseCount()
        {
            return this.phaseCount;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Phase Count={1}, Ordered {2}=[{3}]",
                this.GetType().Name, this.phaseCount, typeof(TalonCallSign).Name,
                string.Join(", ", this.orderedTalonCallSignList));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IList<TalonCallSign> orderedTalonCallSignList = null;

            // Todo
            private int phaseCount = int.MinValue;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITurnOrderReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TurnOrderReport(this.phaseCount, this.orderedTalonCallSignList);
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
            /// <param name="phaseCount"></param>
            /// <returns></returns>
            public Builder SetPhaseCount(int phaseCount)
            {
                this.phaseCount = phaseCount;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="orderedTalonCallSignList"></param>
            /// <returns></returns>
            public Builder SetOrderedTalonCallSignList(IList<TalonCallSign> orderedTalonCallSignList)
            {
                this.orderedTalonCallSignList = new List<TalonCallSign>(orderedTalonCallSignList);
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
                // Check that phaseCount has been set
                if (this.phaseCount == int.MinValue)
                {
                    argumentExceptionSet.Add("phaseCount has not been set");
                }
                // Check that orderedTalonCallSignList has been set
                if (this.orderedTalonCallSignList == null)
                {
                    argumentExceptionSet.Add("Ordered List:" + typeof(TalonCallSign) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}