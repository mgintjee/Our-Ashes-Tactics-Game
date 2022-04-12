using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Engines.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Engines.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Engines.Details.Inters
{
    public interface IEngineGearDetails
    {
        EngineGearID GetEngineGearID();

        ISet<EngineTraitID> GetEngineTraitIDs();
    }
}