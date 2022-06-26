using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Weapons.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Inters
{
    /// <summary>
    /// Trait Model Constants Interface
    /// </summary>
    public interface IGearAttributes
    {
        IUnitAttributes GetUnitAttributes();

        IWeaponAttributes GetWeaponAttributes();
    }
}