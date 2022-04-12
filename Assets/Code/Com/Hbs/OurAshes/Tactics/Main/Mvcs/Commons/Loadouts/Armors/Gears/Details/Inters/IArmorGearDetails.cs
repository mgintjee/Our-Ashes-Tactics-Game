using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Armors.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.Details.Inters
{
    public interface IArmorGearDetails
    {
        ArmorGearID GetArmorGearID();

        ISet<ArmorTraitID> GetArmorTraitIDs();
    }
}