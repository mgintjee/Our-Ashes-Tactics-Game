using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Implementations
{
    /// <summary>
    /// Engagement View Construction Implementation
    /// </summary>
    public struct EngagementViewConstruction : IEngagementViewConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxViewConstruction> _phalanxViewConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">           </param>
        /// <param name="phalanxViewConstructions"></param>
        private EngagementViewConstruction(EngagementType formationType, ISet<IPhalanxViewConstruction> phalanxViewConstructions)
        {
            _engagementType = formationType;
            _phalanxViewConstructions = phalanxViewConstructions;
        }

        /// <inheritdoc/>
        EngagementType IEngagementViewConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxViewConstruction> IEngagementViewConstruction.GetPhalanxViewConstructions()
        {
            return new HashSet<IPhalanxViewConstruction>(_phalanxViewConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IEngagementViewConstruction>
            {
                IBuilder SetEngagementType(EngagementType engagementType);

                IBuilder SetPhalanxViewConstructions(ISet<IPhalanxViewConstruction> phalanxViewConstructions);
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
            private class InternalBuilder : AbstractBuilder<IEngagementViewConstruction>, IBuilder
            {
                // Todo
                private EngagementType _engagementType;

                // Todo
                private ISet<IPhalanxViewConstruction> _phalanxViewConstructions = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxViewConstructions(ISet<IPhalanxViewConstruction> phalanxViewConstructions)
                {
                    if (phalanxViewConstructions != null)
                    {
                        _phalanxViewConstructions = new HashSet<IPhalanxViewConstruction>(phalanxViewConstructions);
                    }
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementViewConstruction BuildObj()
                {
                    return new EngagementViewConstruction(_engagementType, _phalanxViewConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxViewConstructions);
                }
            }
        }
    }
}