using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Implementations
{
    /// <summary>
    /// Mvc Sortie Frame Construction Implementation
    /// </summary>
    public struct MvcSortieFrameConstruction
        : IMvcSortieFrameConstruction
    {
        // Todo
        private readonly IMapConstruction _mapConstruction;

        // Todo
        private readonly IRosterConstruction _rosterConstruction;

        // Todo
        private readonly IScoreConstruction _scoreConstruction;

        // Todo
        private readonly IEngagementConstruction _formationConstruction;

        // Todo
        private readonly IUnityScript _unityScript;

        // Todo
        private readonly SimulationType _simulationType;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationConstruction"></param>
        /// <param name="mapConstruction">      </param>
        /// <param name="rosterConstruction">   </param>
        /// <param name="scoreConstruction">    </param>
        /// <param name="unityScript">          </param>
        /// <param name="simulationType">       </param>
        private MvcSortieFrameConstruction(IEngagementConstruction formationConstruction,
            IMapConstruction mapConstruction, IRosterConstruction rosterConstruction,
            IScoreConstruction scoreConstruction, IUnityScript unityScript, SimulationType simulationType)
        {
            _mapConstruction = mapConstruction;
            _rosterConstruction = rosterConstruction;
            _scoreConstruction = scoreConstruction;
            _formationConstruction = formationConstruction;
            _unityScript = unityScript;
            _simulationType = simulationType;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}" +
                "\n{2}" +
                "\n{3}" +
                "\n{4}" +
                "\n{5}",
                this.GetType().Name,
                StringUtils.Format(typeof(SimulationType), _simulationType),
                _mapConstruction, _rosterConstruction, _scoreConstruction, _formationConstruction);
        }

        /// <inheritdoc/>
        IEngagementConstruction IMvcSortieFrameConstruction.GetFormationConstruction()
        {
            return _formationConstruction;
        }

        /// <inheritdoc/>
        IMapConstruction IMvcSortieFrameConstruction.GetMapConstruction()
        {
            return _mapConstruction;
        }

        /// <inheritdoc/>
        IUnityScript IMvcSortieFrameConstruction.GetUnityScript()
        {
            return _unityScript;
        }

        /// <inheritdoc/>
        IRosterConstruction IMvcSortieFrameConstruction.GetRosterConstruction()
        {
            return _rosterConstruction;
        }

        /// <inheritdoc/>
        IScoreConstruction IMvcSortieFrameConstruction.GetScoreConstruction()
        {
            return _scoreConstruction;
        }

        /// <inheritdoc/>
        SimulationType IMvcSortieFrameConstruction.GetSimulationType()
        {
            return _simulationType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IEngagementConstruction _formationConstruction = null;

            // Todo
            private IRosterConstruction _rosterConstruction = null;

            // Todo
            private IScoreConstruction _scoreConstruction = null;

            // Todo
            private IMapConstruction _mapConstruction = null;

            // Todo
            private IUnityScript _unityScript = null;

            // Todo
            private SimulationType _simulationType = SimulationType.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieFrameConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new MvcSortieFrameConstruction(_formationConstruction,
                        _mapConstruction, _rosterConstruction,
                        _scoreConstruction, _unityScript, _simulationType);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="scoreConstruction"></param>
            /// <returns></returns>
            public Builder SetRosterConstruction(IRosterConstruction scoreConstruction)
            {
                _rosterConstruction = scoreConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="formationConstruction"></param>
            /// <returns></returns>
            public Builder SetEngagementConstruction(IEngagementConstruction formationConstruction)
            {
                _formationConstruction = formationConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="scoreConstruction"></param>
            /// <returns></returns>
            public Builder SetScoreConstruction(IScoreConstruction scoreConstruction)
            {
                _scoreConstruction = scoreConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapConstruction"></param>
            /// <returns></returns>
            public Builder SetMapConstruction(IMapConstruction mapConstruction)
            {
                _mapConstruction = mapConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                _unityScript = unityScript;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                _simulationType = simulationType;
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
                // Check that _formationConstruction has been set
                if (_formationConstruction == null)
                {
                    argumentExceptionSet.Add(typeof(IEngagementConstruction).Name + " cannot be null.");
                }
                // Check that _mapConstruction has been set
                if (_mapConstruction == null)
                {
                    argumentExceptionSet.Add(typeof(IMapConstruction).Name + " cannot be null.");
                }
                // Check that _combatantCallSign has been set
                if (_rosterConstruction == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterConstruction).Name + " cannot be null.");
                }
                // Check that _scoreConstruction has been set
                if (_scoreConstruction == null)
                {
                    argumentExceptionSet.Add(typeof(IScoreConstruction).Name + " cannot be null.");
                }
                // Check that _unityScript has been set
                if (_unityScript == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(IUnityScript).Name + " cannot be null.");
                }
                // Check that _simulationType has been set
                if (_simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " cannot be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}