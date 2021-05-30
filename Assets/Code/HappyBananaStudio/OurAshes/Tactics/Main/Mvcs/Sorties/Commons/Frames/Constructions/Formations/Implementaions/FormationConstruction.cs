using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Formations.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct FormationConstruction
        : IFormationConstruction
    {
        // Todo
        private readonly FormationType _formationType;

        // Todo
        private readonly ISet<IPhalanxConstruction> _phalanxConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">       </param>
        /// <param name="phalanxConstructions"></param>
        private FormationConstruction(FormationType formationType,
            ISet<IPhalanxConstruction> phalanxConstructions)
        {
            _formationType = formationType;
            _phalanxConstructions = phalanxConstructions;
        }

        /// <inheritdoc/>
        FormationType IFormationConstruction.GetFormationType()
        {
            return _formationType;
        }

        /// <inheritdoc/>
        ISet<IPhalanxConstruction> IFormationConstruction.GetPhalanxConstructions()
        {
            return new HashSet<IPhalanxConstruction>(_phalanxConstructions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private FormationType _formationType = FormationType.None;

            // Todo
            private ISet<IPhalanxConstruction> _phalanxConstructions = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IFormationConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new FormationConstruction(_formationType, _phalanxConstructions);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="formationType"></param>
            /// <returns></returns>
            public Builder SetFormationType(FormationType formationType)
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
                if (_formationType == FormationType.None)
                {
                    argumentExceptionSet.Add(typeof(FormationType).Name + " cannot be none.");
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