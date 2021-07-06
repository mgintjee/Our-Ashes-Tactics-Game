using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Reports.Implementations
{
    /// <summary>
    /// Trait Report Implementation
    /// </summary>
    public class TraitReport
        : AbstractReport, ITraitReport
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
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<TraitID> _traitIDs;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ITraitReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new report
                    return new TraitReport(_traitIDs);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="traitIDs"></param>
            /// <returns></returns>
            public Builder SetTraitIDs(ISet<TraitID> traitIDs)
            {
                _traitIDs = new HashSet<TraitID>(traitIDs);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that _traitIDs has been set
                if (_traitIDs == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(TraitID).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}