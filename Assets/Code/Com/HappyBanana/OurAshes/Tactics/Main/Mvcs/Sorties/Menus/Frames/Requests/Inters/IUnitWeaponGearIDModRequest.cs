using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IUnitWeaponGearIDModRequest
        : IMvcRequest
    {
        UnitID GetUnitID();

        WeaponGearID GetWeaponGearID();

        int GetWeaponIndex();
    }
}