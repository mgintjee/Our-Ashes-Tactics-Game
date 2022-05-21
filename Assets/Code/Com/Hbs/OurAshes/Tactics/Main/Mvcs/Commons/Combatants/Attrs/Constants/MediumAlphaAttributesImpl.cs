using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Destructibles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Fireables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Mountables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Movables.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Constants
{
    /// <summary>
    /// Combatant Attributes Implementation
    /// </summary>
    public class MediumAlphaAttributesImpl
        : CombatantAttributesImpl
    {
        public MediumAlphaAttributesImpl()
        {
            this.destructibleAttributes = DestructibleAttributesImpl.Builder.Get()
                .SetArmor(5)
                .SetHealth(15)
                .Build();
            this.fireableAttributes = FireableAttributesImpl.Builder.Get()
                .SetAccuracy(0)
                .SetRange(0)
                .Build();
            this.mountableAttributes = MountableAttributesImpl.Builder.Get()
                .SetArmorGearSize(GearSize.Small)
                .SetCabinGearSize(GearSize.Small)
                .SetEngineGearSize(GearSize.Small)
                .SetWeaponGearSizes(new List<GearSize>() { GearSize.Small })
                .Build();
            this.movableAttributes = MovableAttributesImpl.Builder.Get()
                .SetActions(2)
                .SetMovements(10)
                .Build();
        }
    }
}