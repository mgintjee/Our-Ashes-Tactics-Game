using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Details.Inters
{
    public interface ICabinGearDetails
    {
        CabinGearID GetCabinGearID();

        ISet<CabinTraitID> GetCabinTraitIDs();
    }
}