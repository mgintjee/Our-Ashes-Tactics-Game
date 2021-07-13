using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Skins;
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