using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Cabins.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Cabins.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Cabins.Details.Inters
{
    public interface ICabinGearDetails
    {
        CabinGearID GetCabinGearID();

        ISet<CabinTraitID> GetCabinTraitIDs();
    }
}