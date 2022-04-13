using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Inters
{
    public interface IEngineGearDetails
    {
        EngineGearID GetEngineGearID();

        ISet<EngineTraitID> GetEngineTraitIDs();
    }
}