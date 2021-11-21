using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Loadouts.Traits.IDs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Implementations
{
    /// <summary>
    /// Trait Report Implementation
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
            /// Builder Implementation for this object
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