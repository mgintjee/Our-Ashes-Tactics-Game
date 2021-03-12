namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Comparers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Reports.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// TurnOrder Object Impl
    /// </summary>
    public class TurnOrderObject
        : ITurnOrderObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private int phaseCount;

        // Todo
        private readonly IList<TalonCallSign> orderedTalonCallSignList;

        // Todo
        private readonly ITalonRosterObject rosterObject;

        /// <summary>
        /// Todo
        /// </summary>
        private TurnOrderObject(ITalonRosterObject rosterObject)
        {
            this.rosterObject = rosterObject;
            this.phaseCount = 0;
            this.orderedTalonCallSignList = new List<TalonCallSign>();
        }

        /// <inheritdoc/>
        ITurnOrderReport ITurnOrderObject.GetTurnOrderReport()
        {
            this.UpdateOrderedTalonCallSignList();
            return new TurnOrderReport.Builder()
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
            ISet<TalonCallSign> activeTalonCallSignSet = this.rosterObject.GetActiveTalonCallSignSet();
            this.RemoveInactiveTalonCallSigns(activeTalonCallSignSet);
            if (this.orderedTalonCallSignList.Count == 0)
            {
                logger.Debug("Resetting TurnOrder for new phase.");
                this.phaseCount++;
                foreach (TalonCallSign talonCallSign in activeTalonCallSignSet)
                {
                    this.orderedTalonCallSignList.Add(talonCallSign);
                }
                ((List<TalonCallSign>)this.orderedTalonCallSignList).Sort(new TalonObjectComparerMovement());
                foreach (TalonCallSign talonCallSign in this.orderedTalonCallSignList)
                {
                    this.rosterObject.GetTalonObject(talonCallSign).ResetForNewPhase();
                }
                logger.Debug("Ordered: [?]", string.Join(", ", this.orderedTalonCallSignList));
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
                this.orderedTalonCallSignList.Remove(talonCallSign);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonRosterObject talonRosterObject = null;

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
                    return new TurnOrderObject(this.talonRosterObject);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonRosterObject"></param>
            /// <returns></returns>
            public Builder SetTalonRosterObject(ITalonRosterObject talonRosterObject)
            {
                this.talonRosterObject = talonRosterObject;
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
                // Check that talonRosterObject has been set
                if (this.talonRosterObject == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonRosterObject).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}