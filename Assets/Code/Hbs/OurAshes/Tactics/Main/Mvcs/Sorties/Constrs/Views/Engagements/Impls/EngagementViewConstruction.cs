using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Impls
{
    /// <summary>
    /// Engagement View Construction Implementation
    /// </summary>
    public struct EngagementViewConstruction : IEngagementViewConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxViewConstruction> _phalanxViewConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">     </param>
        /// <param name="phalanxViewConstrs"></param>
        private EngagementViewConstruction(EngagementType formationType, ISet<IPhalanxViewConstruction> phalanxViewConstrs)
        {
            _engagementType = formationType;
            _phalanxViewConstrs = phalanxViewConstrs;
        }

        /// <inheritdoc/>
        EngagementType IEngagementViewConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxViewConstruction> IEngagementViewConstruction.GetPhalanxViewConstrs()
        {
            return new HashSet<IPhalanxViewConstruction>(_phalanxViewConstrs);
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

                IBuilder SetPhalanxViewConstrs(ISet<IPhalanxViewConstruction> phalanxViewConstrs);
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
                private ISet<IPhalanxViewConstruction> _phalanxViewConstrs = null;

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxViewConstrs(ISet<IPhalanxViewConstruction> phalanxViewConstrs)
                {
                    if (phalanxViewConstrs != null)
                    {
                        _phalanxViewConstrs = new HashSet<IPhalanxViewConstruction>(phalanxViewConstrs);
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
                    return new EngagementViewConstruction(_engagementType, _phalanxViewConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxViewConstrs);
                }
            }
        }
    }
}