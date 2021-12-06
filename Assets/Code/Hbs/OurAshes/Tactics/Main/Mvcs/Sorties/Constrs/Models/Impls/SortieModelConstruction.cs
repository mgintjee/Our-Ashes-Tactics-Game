using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Rosters.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Impls
{
    /// <summary>
    /// Sortie Model Construction Implementation
    /// </summary>
    public struct SortieModelConstruction : ISortieModelConstruction
    {
        // Todo
        private readonly IEngagementModelConstruction _engagementModelConstruction;

        // Todo
        private readonly ISortieMapModelConstruction _sortieMapModelConstruction;

        // Todo
        private readonly IRosterModelConstruction _rosterModelConstruction;

        // Todo
        private readonly IScoreConstruction _scoreConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="engagementModelConstruction"></param>
        /// <param name="sortieMapModelConstruction"> </param>
        /// <param name="rosterModelConstruction">    </param>
        private SortieModelConstruction(IEngagementModelConstruction engagementModelConstruction,
            ISortieMapModelConstruction sortieMapModelConstruction, IRosterModelConstruction rosterModelConstruction, IScoreConstruction scoreConstruction)
        {
            _engagementModelConstruction = engagementModelConstruction;
            _sortieMapModelConstruction = sortieMapModelConstruction;
            _rosterModelConstruction = rosterModelConstruction;
            _scoreConstruction = scoreConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementModelConstruction ISortieModelConstruction.GetEngagementModelConstruction()
        {
            return _engagementModelConstruction;
        }

        IRosterModelConstruction ISortieModelConstruction.GetRosterModelConstruction()
        {
            return _rosterModelConstruction;
        }

        IScoreConstruction ISortieModelConstruction.GetScoreConstruction()
        {
            return _scoreConstruction;
        }

        ISortieMapModelConstruction ISortieModelConstruction.GetSortieMapModelConstruction()
        {
            return _sortieMapModelConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieModelConstruction>
            {
                IBuilder SetEngagementModelConstruction(IEngagementModelConstruction engagementModelConstruction);

                IBuilder SetSortieMapModelConstruction(ISortieMapModelConstruction sortieMapModelConstruction);

                IBuilder SetRosterModelConstruction(IRosterModelConstruction rosterModelConstruction);

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
            private class InternalBuilder : AbstractBuilder<ISortieModelConstruction>, IBuilder
            {
                // Todo
                private IEngagementModelConstruction _engagementModelConstruction;

                // Todo
                private IRosterModelConstruction _rosterModelConstruction;

                // Todo
                private ISortieMapModelConstruction _sortieMapModelConstruction;

                private IScoreConstruction _scoreConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementModelConstruction(IEngagementModelConstruction engagementModelConstruction)
                {
                    _engagementModelConstruction = engagementModelConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetSortieMapModelConstruction(ISortieMapModelConstruction sortieMapModelConstruction)
                {
                    _sortieMapModelConstruction = sortieMapModelConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRosterModelConstruction(IRosterModelConstruction rosterModelConstruction)
                {
                    _rosterModelConstruction = rosterModelConstruction;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetScoreConstruction(IScoreConstruction scoreConstruction)
                {
                    _scoreConstruction = scoreConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieModelConstruction BuildObj()
                {
                    return new SortieModelConstruction(_engagementModelConstruction,
                        _sortieMapModelConstruction, _rosterModelConstruction, _scoreConstruction);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementModelConstruction);
                }
            }
        }
    }
}