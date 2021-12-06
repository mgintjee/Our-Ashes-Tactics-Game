using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Engagements.Impls
{
    /// <summary>
    /// Engagement Controller Construction Implementation
    /// </summary>
    public struct EngagementControllerConstruction : IEngagementControllerConstruction
    {
        // Todo
        private readonly EngagementType _engagementType;

        // Todo
        private readonly ISet<IPhalanxControllerConstruction> _phalanxConstrs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">       </param>
        /// <param name="phalanxConstrs"></param>
        private EngagementControllerConstruction(EngagementType formationType, ISet<IPhalanxControllerConstruction> phalanxConstrs)
        {
            _engagementType = formationType;
            _phalanxConstrs = phalanxConstrs;
        }

        /// <inheritdoc/>
        EngagementType IEngagementControllerConstruction.GetEngagementType()
        {
            return _engagementType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxControllerConstruction> IEngagementControllerConstruction.GetPhalanxConstrs()
        {
            return new HashSet<IPhalanxControllerConstruction>(_phalanxConstrs);
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

                IBuilder SetPhalanxControlelrConstrs(ISet<IPhalanxControllerConstruction> phalanxControllerConstrs);
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
                private ISet<IPhalanxControllerConstruction> _phalanxConstrs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetEngagementType(EngagementType engagementType)
                {
                    _engagementType = engagementType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetPhalanxControlelrConstrs(ISet<IPhalanxControllerConstruction> phalanxControllerConstrs)
                {
                    if (phalanxControllerConstrs != null)
                    {
                        _phalanxConstrs = new HashSet<IPhalanxControllerConstruction>(phalanxControllerConstrs);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IEngagementControllerConstruction BuildObj()
                {
                    return new EngagementControllerConstruction(_engagementType, _phalanxConstrs);
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