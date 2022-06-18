using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Inters
{
    public interface IWeaponGearDetails
    {
        WeaponGearID GetWeaponGearID();

        ISet<WeaponTraitID> GetWeaponTraitIDs();
    }
}