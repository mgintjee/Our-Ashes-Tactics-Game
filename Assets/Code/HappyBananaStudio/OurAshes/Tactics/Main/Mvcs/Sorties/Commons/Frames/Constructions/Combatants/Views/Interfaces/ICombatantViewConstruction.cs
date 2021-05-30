using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Skins.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Insignias.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Views.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantSkin GetCombatantSkin();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IInsigniaScheme GetInsigniaScheme();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<GearSkin> GetGearSkins();
    }
}