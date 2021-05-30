using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatantConstruction
        : ICombatantConstruction
    {
        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly ICombatantModelConstruction _combatantModelConstruction;

        // Todo
        private readonly Optional<ICombatantViewConstruction> _combatantViewConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign">         </param>
        /// <param name="combatantModelConstruction"></param>
        /// <param name="combatantViewConstruction"> </param>
        private CombatantConstruction(CombatantCallSign combatantCallSign,
            ICombatantModelConstruction combatantModelConstruction,
            ICombatantViewConstruction combatantViewConstruction)
        {
            _combatantCallSign = combatantCallSign;
            _combatantModelConstruction = combatantModelConstruction;
            _combatantViewConstruction = Optional<ICombatantViewConstruction>.Of(
                combatantViewConstruction);
        }

        /// <inheritdoc/>
        CombatantCallSign ICombatantConstruction.GetCombatantCallSign()
        {
            return _combatantCallSign;
        }

        /// <inheritdoc/>
        ICombatantModelConstruction ICombatantConstruction.GetCombatantModelConstruction()
        {
            return _combatantModelConstruction;
        }

        /// <inheritdoc/>
        Optional<ICombatantViewConstruction> ICombatantConstruction.GetCombatantViewConstruction()
        {
            return _combatantViewConstruction;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantCallSign _combatantCallSign = CombatantCallSign.None;

            // Todo
            private ICombatantModelConstruction _combatantModelConstruction = null;

            // Todo
            private ICombatantViewConstruction _combatantViewConstruction = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new CombatantConstruction(_combatantCallSign,
                        _combatantModelConstruction, _combatantViewConstruction);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantCallSign"></param>
            /// <returns></returns>
            public Builder SetCombatantCallSign(CombatantCallSign combatantCallSign)
            {
                _combatantCallSign = combatantCallSign;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantModelConstruction"></param>
            /// <returns></returns>
            public Builder SetCombatantModelConstruction(ICombatantModelConstruction combatantModelConstruction)
            {
                _combatantModelConstruction = combatantModelConstruction;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantViewConstruction"></param>
            /// <returns></returns>
            public Builder SetCombatantViewConstruction(ICombatantViewConstruction combatantViewConstruction)
            {
                _combatantViewConstruction = combatantViewConstruction;
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
                    argumentExceptionSet.Add(typeof(CombatantCallSign).Name + " cannot be null.");
                }
                // Check that _combatantModelConstruction has been set
                if (_combatantModelConstruction == null)
                {
                    argumentExceptionSet.Add(typeof(ICombatantModelConstruction).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}