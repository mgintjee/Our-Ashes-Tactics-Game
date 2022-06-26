using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Destructibles.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Fireables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Movables.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Sizes;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Constants
{
    /// <summary>
    /// Unit Attributes Implementation
    /// </summary>
    public class LightAlphaAttributesImpl
        : UnitAttributesImpl
    {
        public LightAlphaAttributesImpl()
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