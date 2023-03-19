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
    /// Unit Attributes Implementation
    /// </summary>
    public class MbaAttributesImpl
        : UnitAttributesImpl
    {
        public MbaAttributesImpl()
        {
            this.destructibleAttributes = DestructibleAttributesImpl.Builder.Get()
                .SetArmor(5)
                .SetHealth(20)
                .Build();
            this.fireableAttributes = FireableAttributesImpl.Builder.Get()
                .SetAccuracy(0)
                .SetRange(1)
                .Build();
            this.mountableAttributes = MountableAttributesImpl.Builder.Get()
                .SetArmorGearSize(GearSize.Medium)
                .SetCabinGearSize(GearSize.Medium)
                .SetEngineGearSize(GearSize.Medium)
                .SetWeaponGearSizes(new List<GearSize>() { GearSize.Medium, GearSize.Medium })
                .Build();
            this.movableAttributes = MovableAttributesImpl.Builder.Get()
                .SetActions(2)
                .SetMovements(10)
                .Build();
        }
    }
}