using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Details.Inters
{
    public interface IEngineGearDetails
    {
        EngineGearID GetGearID();

        ISet<EngineTraitID> GetEngineTraitIDs();
    }
}