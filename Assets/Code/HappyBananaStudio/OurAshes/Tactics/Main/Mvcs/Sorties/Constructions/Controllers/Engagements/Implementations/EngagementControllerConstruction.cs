using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Implementations
{
    /// <summary>
    /// Engagement Controller Construction Implementation
    /// </summary>
    public struct EngagementControllerConstruction : IEngagementControllerConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxControllerConstruction> _phalanxConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">       </param>
        /// <param name="phalanxConstructions"></param>
        private EngagementControllerConstruction(EngagementType formationType, ISet<IPhalanxControllerConstruction> phalanxConstructions)
        {
            _engagementType = formationType;
            _phalanxConstructions = phalanxConstructions;
        }

        /// <inheritdoc/>
        EngagementType IEngagementControllerConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxControllerConstruction> IEngagementControllerConstruction.GetPhalanxConstructions()
        {
            return new HashSet<IPhalanxControllerConstruction>(_phalanxConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IEngagementControllerConstruction>
            {
                IBuilder SetEngagementType(EngagementType engagementType);

                IBuilder SetPhalanxControlelrConstructions(ISet<IPhalanxControllerConstruction> phalanxControllerConstructions);
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
            private class InternalBuilder : AbstractBuilder<IEngagementControllerConstruction>, IBuilder
            {
                // Todo
                private EngagementType _engagementType;

                // Todo
                private ISet<IPhalanxControllerConstruction> _phalanxConstructions;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxControlelrConstructions(ISet<IPhalanxControllerConstruction> phalanxControllerConstructions)
                {
                    if (phalanxControllerConstructions != null)
                    {
                        _phalanxConstructions = new HashSet<IPhalanxControllerConstruction>(phalanxControllerConstructions);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementControllerConstruction BuildObj()
                {
                    return new EngagementControllerConstruction(_engagementType, _phalanxConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxConstructions);
                }
            }
        }
    }
}