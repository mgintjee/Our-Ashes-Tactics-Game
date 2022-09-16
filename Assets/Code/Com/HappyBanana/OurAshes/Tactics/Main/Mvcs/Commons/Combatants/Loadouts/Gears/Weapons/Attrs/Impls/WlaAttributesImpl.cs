﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Attrs.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Weapons.Impls;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.Attrs.Impls
{
    public class WlaAttributesImpl
        : AbstractGearAttributes<WeaponGearID>
    {
        public WlaAttributesImpl()
        {
            this.id = WeaponGearID.WLA;
            this.gearSize = GearSize.Large;
            this.unitAttributes = UnitAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .SetAccuracy(75)
                .SetArmorDamage(1)
                .SetArmorPenetration(2)
                .SetHealthDamage(1)
                .SetRange(3)
                .SetSalvo(3)
                .Build();
        }
    }
}