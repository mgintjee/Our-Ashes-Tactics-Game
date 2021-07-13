using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Weapons.Attributes.Utils
{
    /// <summary>
    /// Weapon Attributes Util
    /// </summary>
    public static class WeaponAttributesUtil
    {
        public static IWeaponAttributes Build(ICollection<IWeaponAttributes> weaponAttributes)
        {
            float accuracy = 0.0f;
            float armorDamage = 0.0f;
            float armorPenetration = 0.0f;
            float healthDamage = 0.0f;
            float range = 0.0f;
            float salvo = 0.0f;

            foreach (IWeaponAttributes attributes in weaponAttributes)
            {
                if (attributes.GetAccuracy() > accuracy)
                {
                    accuracy = attributes.GetAccuracy();
                }
                if (attributes.GetArmorDamage() > armorDamage)
                {
                    armorDamage = attributes.GetArmorDamage();
                }
                if (attributes.GetArmorPenetration() > armorPenetration)
                {
                    armorPenetration = attributes.GetArmorPenetration();
                }
                if (attributes.GetHealthDamage() > healthDamage)
                {
                    healthDamage = attributes.GetHealthDamage();
                }
                if (attributes.GetRange() > range)
                {
                    range = attributes.GetRange();
                }
                if (attributes.GetSalvo() > salvo)
                {
                    salvo = attributes.GetSalvo();
                }
            }

            return WeaponAttributes.Builder.Get()
                .SetAccuracy(accuracy)
                .SetArmorDamage(armorDamage)
                .SetArmorPenetration(armorPenetration)
                .SetHealthDamage(healthDamage)
                .SetRange(range)
                .SetSalvo(salvo)
                .Build();
        }
    }
}