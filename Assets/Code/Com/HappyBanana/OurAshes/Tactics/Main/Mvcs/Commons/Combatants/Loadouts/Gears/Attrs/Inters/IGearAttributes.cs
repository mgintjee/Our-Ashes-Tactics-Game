using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Inters
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGearAttributes
    {
        IUnitAttributes GetUnitAttributes();

        IWeaponAttributes GetWeaponAttributes();
    }
}