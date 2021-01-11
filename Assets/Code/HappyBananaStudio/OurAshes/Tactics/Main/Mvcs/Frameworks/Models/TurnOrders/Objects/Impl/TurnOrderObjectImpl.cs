namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// TurnOrder Object Impl
    /// </summary>
    public class TurnOrderObjectImpl
        : ITurnOrderObject
    {
        // Todo
        private int phaseCount;

        // Todo
        private IList<TalonCallSign> orderedTalonCallSignList;

        /// <summary>
        /// Todo
        /// </summary>
        private TurnOrderObjectImpl()
        {
            this.phaseCount = 0;
            this.orderedTalonCallSignList = new List<TalonCallSign>();
        }

        /// <inheritdoc/>
        ITurnOrderReport ITurnOrderObject.GetTurnOrderReport()
        {
            this.UpdateOrderedTalonCallSignList();
            return new TurnOrderReportImpl.Builder()
                .SetPhaseCount(this.phaseCount)
                .SetOrderedTalonCallSignList(this.orderedTalonCallSignList)
                .Build();
        }

        /// <inheritdoc/>
        void ITurnOrderObject.TalonCallSignCompletedTurn(TalonCallSign talonCallSign)
        {
            this.orderedTalonCallSignList.Remove(talonCallSign);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void UpdateOrderedTalonCallSignList()
        {
            ISet<TalonCallSign> activeTalonCallSignSet = RosterManager.GetActiveTalonCallSignSet();
            this.RemoveInactiveTalonCallSigns(activeTalonCallSignSet);
            if (this.orderedTalonCallSignList.Count == 0)
            {
                this.phaseCount++;
                orderedTalonCallSignList = new List<TalonCallSign>(activeTalonCallSignSet);
                ((List<TalonCallSign>)this.orderedTalonCallSignList).Sort(new TalonObjectComparerMovementImpl());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void RemoveInactiveTalonCallSigns(ISet<TalonCallSign> activeTalonCallSignSet)
        {
            ISet<TalonCallSign> inactiveTalonCallSignSet = new HashSet<TalonCallSign>();
            foreach (TalonCallSign talonCallSign in this.orderedTalonCallSignList)
            {
                if (!activeTalonCallSignSet.Contains(talonCallSign))
                {
                    inactiveTalonCallSignSet.Add(talonCallSign);
                }
            }
            foreach (TalonCallSign talonCallSign in inactiveTalonCallSignSet)
            {
                orderedTalonCallSignList.Remove(talonCallSign);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITurnOrderObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TurnOrderObjectImpl();
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
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
                return argumentExceptionSet;
            }
        }
    }
}