using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters
{
    public interface ILoadoutDetails
    {
        IArmorGearDetails GetArmorGearDetails();

        ICabinGearDetails GetCabinGearDetails();

        IEngineGearDetails GetEngineGearDetails();

        IList<IWeaponGearDetails> GetWeaponGearDetails();
    }
}