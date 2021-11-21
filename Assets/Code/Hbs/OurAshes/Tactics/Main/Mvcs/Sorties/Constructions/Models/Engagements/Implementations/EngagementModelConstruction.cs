using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Implementations
{
    /// <summary>
    /// Engagement Model Construction Implementation
    /// </summary>
    public struct EngagementModelConstruction : IEngagementModelConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxModelConstruction> _phalanxConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">       </param>
        /// <param name="phalanxConstructions"></param>
        private EngagementModelConstruction(EngagementType formationType, ISet<IPhalanxModelConstruction> phalanxConstructions)
        {
            _engagementType = formationType;
            _phalanxConstructions = phalanxConstructions;
        }

        /// <inheritdoc/>
        EngagementType IEngagementModelConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxModelConstruction> IEngagementModelConstruction.GetPhalanxConstructions()
        {
            return new HashSet<IPhalanxModelConstruction>(_phalanxConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IEngagementModelConstruction>
            {
                IBuilder SetEngagementType(EngagementType engagementType);

                IBuilder SetPhalanxModelConstructions(ISet<IPhalanxModelConstruction> phalanxModelConstructions);
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
            private class InternalBuilder : AbstractBuilder<IEngagementModelConstruction>, IBuilder
            {
                // Todo
                private EngagementType _engagementType;

                // Todo
                private ISet<IPhalanxModelConstruction> _phalanxModelConstructions;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxModelConstructions(ISet<IPhalanxModelConstruction> phalanxModelConstructions)
                {
                    if (phalanxModelConstructions != null)
                    {
                        _phalanxModelConstructions = new HashSet<IPhalanxModelConstruction>(phalanxModelConstructions);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementModelConstruction BuildObj()
                {
                    return new EngagementModelConstruction(_engagementType, _phalanxModelConstructions);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxModelConstructions);
                }
            }
        }
    }
}