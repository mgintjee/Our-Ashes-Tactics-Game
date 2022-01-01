using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Impls
{
    /// <summary>
    /// Engagement Model Construction Impl
    /// </summary>
    public struct EngagementModelConstruction : IEngagementModelConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxModelConstruction> _phalanxConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType"> </param>
        /// <param name="phalanxConstrs"></param>
        private EngagementModelConstruction(EngagementType formationType, ISet<IPhalanxModelConstruction> phalanxConstrs)
        {
            _engagementType = formationType;
            _phalanxConstrs = phalanxConstrs;
        }

        /// <inheritdoc/>
        EngagementType IEngagementModelConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxModelConstruction> IEngagementModelConstruction.GetPhalanxConstrs()
        {
            return new HashSet<IPhalanxModelConstruction>(_phalanxConstrs);
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

                IBuilder SetPhalanxModelConstrs(ISet<IPhalanxModelConstruction> phalanxModelConstrs);
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
                private ISet<IPhalanxModelConstruction> _phalanxModelConstrs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxModelConstrs(ISet<IPhalanxModelConstruction> phalanxModelConstrs)
                {
                    if (phalanxModelConstrs != null)
                    {
                        _phalanxModelConstrs = new HashSet<IPhalanxModelConstruction>(phalanxModelConstrs);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementModelConstruction BuildObj()
                {
                    return new EngagementModelConstruction(_engagementType, _phalanxModelConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxModelConstrs);
                }
            }
        }
    }
}