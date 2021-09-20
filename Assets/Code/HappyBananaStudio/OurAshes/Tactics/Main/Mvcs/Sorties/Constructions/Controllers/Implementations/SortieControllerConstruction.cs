using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Implementations
{
    /// <summary>
    /// Sortie Controller Construction Implementation
    /// </summary>
    public struct SortieControllerConstruction : ISortieControllerConstruction
    {
        // Todo
        private readonly IEngagementControllerConstruction _engagementControllerConstruction;

        private SortieControllerConstruction(IEngagementControllerConstruction engagementControllerConstruction)
        {
            _engagementControllerConstruction = engagementControllerConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementControllerConstruction ISortieControllerConstruction.GetEngagementControllerConstruction()
        {
            return _engagementControllerConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<ISortieControllerConstruction>
            {
                IBuilder SetEngagementControllerConstruction(IEngagementControllerConstruction engagementControllerConstruction);
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
            private class InternalBuilder : AbstractBuilder<ISortieControllerConstruction>, IBuilder
            {
                // Todo
                private IEngagementControllerConstruction _engagementControllerConstruction;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementControllerConstruction(IEngagementControllerConstruction engagementControllerConstruction)
                {
                    _engagementControllerConstruction = engagementControllerConstruction;
                    return this;
                }

                /// <inheritdoc/>
                protected override ISortieControllerConstruction BuildObj()
                {
                    return new SortieControllerConstruction(_engagementControllerConstruction);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementControllerConstruction);
                }
            }
        }
    }
}