using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Destructibles.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Fireables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Mountables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Movables.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.Attrs.Impls
{
    /// <summary>
    /// HeavyAlpha Unit Attributes Implementation
    /// </summary>
    public class McaAttributesImpl
        : UnitAttributesImpl
    {
        public McaAttributesImpl()
        {
            this.destructibleAttributes = DestructibleAttributesImpl.Builder.Get()
                .SetArmor(2)
                .SetHealth(15)
                .Build();
            this.fireableAttributes = FireableAttributesImpl.Builder.Get()
                .SetAccuracy(0)
                .SetRange(0)
                .Build();
            this.mountableAttributes = MountableAttributesImpl.Builder.Get()
                .SetArmorGearSize(GearSize.Small)
                .SetCabinGearSize(GearSize.Medium)
                .SetEngineGearSize(GearSize.Large)
                .SetWeaponGearSizes(new List<GearSize>() { GearSize.Small, GearSize.Small, GearSize.Small, GearSize.Small })
                .Build();
            this.movableAttributes = MovableAttributesImpl.Builder.Get()
                .SetActions(3)
                .SetMovements(15)
                .Build();
        }
    }
}