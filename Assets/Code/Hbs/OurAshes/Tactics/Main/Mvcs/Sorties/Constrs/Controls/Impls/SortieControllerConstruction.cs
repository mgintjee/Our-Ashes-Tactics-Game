using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Impls
{
    /// <summary>
    /// Sortie Control Construction Impl
    /// </summary>
    public struct SortieControlConstruction : ISortieControlConstruction
    {
        // Todo
        private readonly IEngagementControlConstruction _engagementControlConstruction;

        private SortieControlConstruction(IEngagementControlConstruction engagementControlConstruction)
        {
            _engagementControlConstruction = engagementControlConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementControlConstruction ISortieControlConstruction.GetEngagementControlConstruction()
        {
            return _engagementControlConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieControlConstruction>
            {
                IBuilder SetEngagementControlConstruction(IEngagementControlConstruction engagementControlConstruction);
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
            private class InternalBuilder : AbstractBuilder<ISortieControlConstruction>, IBuilder
            {
                // Todo
                private IEngagementControlConstruction _engagementControlConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementControlConstruction(IEngagementControlConstruction engagementControlConstruction)
                {
                    _engagementControlConstruction = engagementControlConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieControlConstruction BuildObj()
                {
                    return new SortieControlConstruction(_engagementControlConstruction);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementControlConstruction);
                }
            }
        }
    }
}