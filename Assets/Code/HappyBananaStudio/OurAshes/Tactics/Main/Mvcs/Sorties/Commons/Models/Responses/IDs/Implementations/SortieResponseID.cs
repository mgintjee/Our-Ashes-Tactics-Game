﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Implementations
{
    /// <summary>
    /// Sortie Response ID Implementation
    /// </summary>
    public class SortieResponseID
        : ISortieResponseID
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly int _action;

        // Todo
        private readonly int _phase;

        // Todo
        private readonly int _turn;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phase"> </param>
        /// <param name="turn">  </param>
        /// <param name="action"></param>
        public SortieResponseID(int phase, int turn, int action)
        {
            _phase = phase;
            _turn = turn;
            _action = action;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is ISortieResponseID actionID)
            {
                return actionID.GetPhase() == _phase &&
                    actionID.GetTurn() == _turn &&
                    actionID.GetAction() == _action;
            }
            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1198573990;
            hashCode = hashCode * -1521134295 + _action.GetHashCode();
            hashCode = hashCode * -1521134295 + _phase.GetHashCode();
            hashCode = hashCode * -1521134295 + _turn.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1}.{2}.{3})",
                this.GetType().Name, _phase, _turn, _action);
        }

        /// <inheritdoc/>
        int ISortieResponseID.GetAction()
        {
            return _action;
        }

        /// <inheritdoc/>
        int ISortieResponseID.GetPhase()
        {
            return _phase;
        }

        /// <inheritdoc/>
        int ISortieResponseID.GetTurn()
        {
            return _turn;
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieResponseID.IncrementAction()
        {
            _logger.Info("Incrementing {}'s action.", this);
            return new SortieResponseID(_phase, _turn, _action + 1);
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieResponseID.IncrementPhase()
        {
            _logger.Info("Incrementing {}'s phase.", this);
            return new SortieResponseID(_phase + 1, 0, 0);
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieResponseID.IncrementTurn()
        {
            _logger.Info("Incrementing {}'s turn.", this);
            return new SortieResponseID(_phase, _turn + 1, 0);
        }
    }
}