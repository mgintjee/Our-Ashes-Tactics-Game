using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Views.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CombatantViewConstruction
        : ICombatantViewConstruction
    {
        // Todo
        private readonly CombatantSkin _combatantSkin;

        // Todo
        private readonly IList<GearSkin> _weaponSkins;

        // Todo
        private readonly IInsigniaScheme _insigniaScheme;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantSkin"> </param>
        /// <param name="insigniaScheme"></param>
        /// <param name="gearSkins">   </param>
        private CombatantViewConstruction(CombatantSkin combatantSkin,
            IInsigniaScheme insigniaScheme, IList<GearSkin> gearSkins)
        {
            _combatantSkin = combatantSkin;
            _insigniaScheme = insigniaScheme;
            _weaponSkins = gearSkins;
        }

        /// <inheritdoc/>
        CombatantSkin ICombatantViewConstruction.GetCombatantSkin()
        {
            return _combatantSkin;
        }

        /// <inheritdoc/>
        IInsigniaScheme ICombatantViewConstruction.GetInsigniaScheme()
        {
            return _insigniaScheme;
        }

        /// <inheritdoc/>
        IList<GearSkin> ICombatantViewConstruction.GetGearSkins()
        {
            return new List<GearSkin>(_weaponSkins);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private CombatantSkin _combatantSkin = CombatantSkin.None;

            // Todo
            private IInsigniaScheme _insigniaScheme = null;

            // Todo
            private IList<GearSkin> _gearSkins = new List<GearSkin>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICombatantViewConstruction Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new CombatantViewConstruction(_combatantSkin, _insigniaScheme, _gearSkins);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantSkin"></param>
            /// <returns></returns>
            public Builder SetCombatantSkin(CombatantSkin combatantSkin)
            {
                _combatantSkin = combatantSkin;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="insigniaScheme"></param>
            /// <returns></returns>
            public Builder SetInsigniaScheme(IInsigniaScheme insigniaScheme)
            {
                _insigniaScheme = insigniaScheme;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSkins"></param>
            /// <returns></returns>
            public Builder SetGearSkin(IList<GearSkin> gearSkins)
            {
                if (gearSkins != null)
                {
                    _gearSkins = new List<GearSkin>(gearSkins);
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
                // Check that _combatantSkin has been set
                if (_combatantSkin == CombatantSkin.None)
                {
                    argumentExceptionSet.Add(typeof(CombatantSkin).Name + " cannot be none.");
                }
                // Check that _insigniaScheme has been set
                if (_insigniaScheme == null)
                {
                    argumentExceptionSet.Add(typeof(IInsigniaScheme).Name + " cannot be null.");
                }
                // Check that _gearSkins has been set
                if (_gearSkins == null)
                {
                    argumentExceptionSet.Add("List: " + typeof(GearSkin).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}