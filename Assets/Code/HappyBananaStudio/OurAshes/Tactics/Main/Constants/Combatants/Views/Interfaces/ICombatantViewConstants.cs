using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Combatants.Views.Interfaces
{
    /// <summary>
    /// Combatant View Constants Interface
    /// </summary>
    public interface ICombatantViewConstants
    {
        CombatantID GetCombatantID();

        ISet<CombatantSkin> GetCombatantSkins();
    }
}