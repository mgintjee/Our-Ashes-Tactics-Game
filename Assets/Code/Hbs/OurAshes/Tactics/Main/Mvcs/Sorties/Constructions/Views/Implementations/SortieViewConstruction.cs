using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Implementations
{
    /// <summary>
    /// Sortie View Construction Implementation
    /// </summary>
    public struct SortieViewConstruction : ISortieViewConstruction
    {
        // Todo
        private readonly IEngagementViewConstruction _engagementViewConstruction;

        // Todo
        private readonly ISortieMapViewConstruction _sortieMapViewConstruction;

        // Todo
        private readonly IRosterViewConstruction _rosterViewConstruction;

        // Todo
        private readonly IScoreConstruction _scoreConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engagementViewConstruction"></param>
        /// <param name="sortieMapViewConstruction"> </param>
        /// <param name="rosterViewConstruction">    </param>
        private SortieViewConstruction(IEngagementViewConstruction engagementViewConstruction,
            ISortieMapViewConstruction sortieMapViewConstruction, IRosterViewConstruction rosterViewConstruction, IScoreConstruction scoreConstruction)
        {
            _engagementViewConstruction = engagementViewConstruction;
            _sortieMapViewConstruction = sortieMapViewConstruction;
            _rosterViewConstruction = rosterViewConstruction;
            _scoreConstruction = scoreConstruction;
        }

        IEngagementViewConstruction ISortieViewConstruction.GetEngagementViewConstruction()
        {
            return _engagementViewConstruction;
        }

        IRosterViewConstruction ISortieViewConstruction.GetRosterViewConstruction()
        {
            return _rosterViewConstruction;
        }

        IScoreConstruction ISortieViewConstruction.GetScoreConstruction()
        {
            return _scoreConstruction;
        }

        ISortieMapViewConstruction ISortieViewConstruction.GetSortieMapViewConstruction()
        {
            return _sortieMapViewConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieViewConstruction>
            {
                IBuilder SetEngagementViewConstruction(IEngagementViewConstruction engagementViewConstruction);

                IBuilder SetSortieMapViewConstruction(ISortieMapViewConstruction sortieMapViewConstruction);

                IBuilder SetRosterViewConstruction(IRosterViewConstruction rosterViewConstruction);

                IBuilder SetScoreConstruction(IScoreConstruction scoreConstruction);
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
            private class InternalBuilder : AbstractBuilder<ISortieViewConstruction>, IBuilder
            {
                // Todo
                private IEngagementViewConstruction _engagementViewConstruction;

                // Todo
                private IRosterViewConstruction _rosterViewConstruction;

                // Todo
                private ISortieMapViewConstruction _sortieMapViewConstruction;

                // Todo
                private IScoreConstruction _scoreConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementViewConstruction(IEngagementViewConstruction engagementViewConstruction)
                {
                    _engagementViewConstruction = engagementViewConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieMapViewConstruction(ISortieMapViewConstruction sortieMapViewConstruction)
                {
                    _sortieMapViewConstruction = sortieMapViewConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRosterViewConstruction(IRosterViewConstruction rosterViewConstruction)
                {
                    _rosterViewConstruction = rosterViewConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetScoreConstruction(IScoreConstruction scoreConstruction)
                {
                    _scoreConstruction = scoreConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieViewConstruction BuildObj()
                {
                    return new SortieViewConstruction(_engagementViewConstruction, _sortieMapViewConstruction, _rosterViewConstruction, _scoreConstruction);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementViewConstruction);
                }
            }
        }
    }
}