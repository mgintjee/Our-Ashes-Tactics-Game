using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct EngagementConstruction
        : IEngagementConstruction
    {
        // Todo
        private readonly EngagementType _formationType;

        // Todo
        private readonly ISet<IPhalanxConstruction> _phalanxConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">       </param>
        /// <param name="phalanxConstructions"></param>
        private EngagementConstruction(EngagementType formationType,
            ISet<IPhalanxConstruction> phalanxConstructions)
        {
            _formationType = formationType;
            _phalanxConstructions = phalanxConstructions;
        }

        /// <inheritdoc/>
        EngagementType IEngagementConstruction.GetEngagementType()
        {
            return _formationType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxConstruction> IEngagementConstruction.GetPhalanxConstructions()
        {
            return new HashSet<IPhalanxConstruction>(_phalanxConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EngagementType _formationType = EngagementType.None;

            // Todo
            private ISet<IPhalanxConstruction> _phalanxConstructions = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngagementConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new EngagementConstruction(_formationType, _phalanxConstructions);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="formationType"></param>
            /// <returns></returns>
            public Builder SetFormationType(EngagementType formationType)
            {
                _formationType = formationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxConstructions"></param>
            /// <returns></returns>
            public Builder SetPhalanxConstructions(ISet<IPhalanxConstruction> phalanxConstructions)
            {
                if (phalanxConstructions != null)
                {
                    _phalanxConstructions = new HashSet<IPhalanxConstruction>(phalanxConstructions);
                }
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
                // Check that _formationType has been set
                if (_formationType == EngagementType.None)
                {
                    argumentExceptionSet.Add(typeof(EngagementType).Name + " cannot be none.");
                }
                // Check that _phalanxConstructions has been set
                if (_phalanxConstructions == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxConstruction).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}