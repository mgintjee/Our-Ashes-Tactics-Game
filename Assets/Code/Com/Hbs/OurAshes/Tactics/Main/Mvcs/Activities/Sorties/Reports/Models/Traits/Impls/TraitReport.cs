using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Traits.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Traits.Impls
{
    /// <summary>
    /// Trait Report Impl
    /// </summary>
    public class TraitReport : AbstractReport, ITraitReport
    {
        // Todo
        private readonly ISet<TraitID> _traitIDs;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitIDs"></param>
        public TraitReport(ISet<TraitID> traitIDs)
        {
            _traitIDs = traitIDs;
        }

        /// <inheritdoc/>
        ISet<TraitID> ITraitReport.GetTraitIDs()
        {
            return new HashSet<TraitID>(_traitIDs);
        }

        /// <inheritdoc/>
        /// s
        protected override string GetContent()
        {
            return string.Format("{0}", StringUtils.FormatCollection(_traitIDs));
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ITraitReport>
            {
                IBuilder SetTraitIDs(ISet<TraitID> traitIDs);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ITraitReport>, IBuilder
            {
                private ISet<TraitID> _traitIDs;

                /// <inheritdoc/>
                IBuilder IBuilder.SetTraitIDs(ISet<TraitID> traitIDs)
                {
                    _traitIDs = traitIDs;
                    return this;
                }

                /// <inheritdoc/>
                protected override ITraitReport BuildObj()
                {
                    return new TraitReport(_traitIDs);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _traitIDs);
                }
            }
        }
    }
}