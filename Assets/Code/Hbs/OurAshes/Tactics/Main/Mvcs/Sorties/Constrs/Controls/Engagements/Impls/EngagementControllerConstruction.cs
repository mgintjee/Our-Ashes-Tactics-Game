using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Impls
{
    /// <summary>
    /// Engagement Control Construction Impl
    /// </summary>
    public struct EngagementControlConstruction : IEngagementControlConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxControlConstruction> _phalanxConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType"> </param>
        /// <param name="phalanxConstrs"></param>
        private EngagementControlConstruction(EngagementType formationType, ISet<IPhalanxControlConstruction> phalanxConstrs)
        {
            _engagementType = formationType;
            _phalanxConstrs = phalanxConstrs;
        }

        /// <inheritdoc/>
        EngagementType IEngagementControlConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxControlConstruction> IEngagementControlConstruction.GetPhalanxConstrs()
        {
            return new HashSet<IPhalanxControlConstruction>(_phalanxConstrs);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IEngagementControlConstruction>
            {
                IBuilder SetEngagementType(EngagementType engagementType);

                IBuilder SetPhalanxControlelrConstrs(ISet<IPhalanxControlConstruction> phalanxControlConstrs);
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
            private class InternalBuilder : AbstractBuilder<IEngagementControlConstruction>, IBuilder
            {
                // Todo
                private EngagementType _engagementType;

                // Todo
                private ISet<IPhalanxControlConstruction> _phalanxConstrs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxControlelrConstrs(ISet<IPhalanxControlConstruction> phalanxControlConstrs)
                {
                    if (phalanxControlConstrs != null)
                    {
                        _phalanxConstrs = new HashSet<IPhalanxControlConstruction>(phalanxControlConstrs);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementControlConstruction BuildObj()
                {
                    return new EngagementControlConstruction(_engagementType, _phalanxConstrs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _engagementType);
                    this.Validate(invalidReasons, _phalanxConstrs);
                }
            }
        }
    }
}