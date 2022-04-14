﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Attrs.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Combatants.Attrs.Weapons.Impls;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Traits.Attrs.Impls
{
    /// <summary>
    /// Trait Model Constants Impl
    /// </summary>
    public class WeaponTraitAlphaAlphaAttributesImpl
        : AbstractGearAttributes
    {
        public WeaponTraitAlphaAlphaAttributesImpl()
        {
            this.combatantAttributes = CombatantAttributesImpl.Builder.Get()
                .Build();
            this.weaponAttributes = WeaponAttributesImpl.Builder.Get()
                .Build();
        }
    }
}