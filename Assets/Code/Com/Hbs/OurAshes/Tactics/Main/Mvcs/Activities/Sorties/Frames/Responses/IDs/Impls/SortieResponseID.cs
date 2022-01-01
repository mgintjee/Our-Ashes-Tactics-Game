using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Responses.IDs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Responses.IDs.Impls
{
    /// <summary>
    /// Sortie Response ID Impl
    /// </summary>
    public class SortieResponseID
        : ISortieResponseID
    {
        // Provides logging capability
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

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
            logger.Info("Incrementing {}'s action.", this);
            return new SortieResponseID(_phase, _turn, _action + 1);
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieResponseID.IncrementPhase()
        {
            logger.Info("Incrementing {}'s phase.", this);
            return new SortieResponseID(_phase + 1, 0, 0);
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieResponseID.IncrementTurn()
        {
            logger.Info("Incrementing {}'s turn.", this);
            return new SortieResponseID(_phase, _turn + 1, 0);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieResponseID>
            {
                IBuilder SetAction(int action);

                IBuilder SetPhase(int phase);

                IBuilder SetTurn(int turn);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ISortieResponseID>, IBuilder
            {
                // Todo
                private int _action;

                // Todo
                private int _phase;

                // Todo
                private int _turn;

                /// <inheritdoc/>
                IBuilder IBuilder.SetAction(int action)
                {
                    _action = action;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhase(int phase)
                {
                    _phase = phase;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetTurn(int turn)
                {
                    _turn = turn;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieResponseID BuildObj()
                {
                    return new SortieResponseID(_phase, _turn, _action);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _action);
                    this.Validate(invalidReasons, _phase);
                    this.Validate(invalidReasons, _turn);
                }
            }
        }
    }
}