using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Weapons.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Weapons.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Weapons.Details.Inters
{
    public interface IWeaponGearDetails
    {
        WeaponGearID GetWeaponGearID();

        ISet<WeaponTraitID> GetWeaponTraitIDs();
    }
}