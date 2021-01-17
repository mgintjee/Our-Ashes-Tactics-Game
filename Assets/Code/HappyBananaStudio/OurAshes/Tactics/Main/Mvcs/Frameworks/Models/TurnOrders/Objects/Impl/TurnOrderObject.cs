namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.TurnOrders.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers;
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
        private IList<TalonCallSign> orderedTalonCallSignList;

        /// <summary>
        /// Todo
        /// </summary>
        public TurnOrderObject()
        {
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
            ISet<TalonCallSign> activeTalonCallSignSet = RosterManager.GetActiveTalonCallSignSet();
            this.RemoveInactiveTalonCallSigns(activeTalonCallSignSet);
            if (this.orderedTalonCallSignList.Count == 0)
            {
                logger.Debug("Resetting TurnOrder for new phase.");
                this.phaseCount++;
                this.orderedTalonCallSignList = new List<TalonCallSign>(activeTalonCallSignSet);
                ((List<TalonCallSign>)this.orderedTalonCallSignList).Sort(new TalonObjectComparerMovement());
                foreach (TalonCallSign talonCallSign in this.orderedTalonCallSignList)
                {
                    RosterManager.GetTalonObject(talonCallSign).ResetForNewPhase();
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
    }
}