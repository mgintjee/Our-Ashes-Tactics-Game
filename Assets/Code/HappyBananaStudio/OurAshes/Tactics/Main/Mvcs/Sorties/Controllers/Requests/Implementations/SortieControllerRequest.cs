using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Implementations
{
    /// <summary>
    /// Sortie Controller Request Interface
    /// </summary>
    public class SortieControllerRequest
        : ISortieControllerRequest
    {
        // Todo
        private readonly CombatantCallSign _callSign;

        // Todo
        private readonly IPath _path;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        /// <param name="path">    </param>
        private SortieControllerRequest(CombatantCallSign callSign, IPath path)
        {
            _callSign = callSign;
            _path = path;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n{1}" +
                "\n{2}",
                this.GetType().Name,
                StringUtils.Format(typeof(CombatantCallSign), this._callSign));
        }

        /// <inheritdoc/>
        CombatantCallSign ISortieControllerRequest.GetCallSign()
        {
            return _callSign;
        }

        /// <inheritdoc/>
        IPath ISortieControllerRequest.GetPath()
        {
            return _path;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private IPath _path = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieControllerRequest Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new SortieControllerRequest(_combatantCallSign, _path);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSigns"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSigns)
            {
                _combatantCallSign = combatantCallSigns;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public Builder SetPath(IPath path)
            {
                _path = path;
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
                // Check that _combatantCallSign has been set
                if (_combatantCallSign == CombatantCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantCallSign).Name + " cannot be none.");
                }
                // Check that _path has been set
                if (_path == null)
                {
                    argumentExceptionSet.Add(typeof(IPath).Name + " cannot be none.");
                }
                return argumentExceptionSet;
            }
        }
    }
}