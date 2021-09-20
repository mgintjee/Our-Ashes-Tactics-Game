using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Gears.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Constants.Loadouts.Models.Traits.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Traits.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.Attributes.Weapons.Utils
{
    /// <summary>
    /// Weapon Attributes Util
    /// </summary>
    public static class WeaponAttributesUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gearReport"></param>
        /// <returns></returns>
        public static IWeaponAttributes Build(IGearReport gearReport)
        {
            ISet<IWeaponAttributes> weaponAttributes = new HashSet<IWeaponAttributes>();

            GearModelConstantsManager.GetConstants(gearReport.GetGearID()).IfPresent(gearModelConstants =>
            {
                weaponAttributes.Add(gearModelConstants.GetWeaponAttributes());
            });
            weaponAttributes.Add(Build(gearReport.GetTraitReport()));
            return Build(weaponAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitReport"></param>
        /// <returns></returns>
        public static IWeaponAttributes Build(ITraitReport traitReport)
        {
            ISet<IWeaponAttributes> weaponAttributes = new HashSet<IWeaponAttributes>();

            foreach (TraitID traitID in traitReport.GetTraitIDs())
            {
                TraitModelConstantsManager.GetConstants(traitID).IfPresent(traitModelConstants =>
                {
                    weaponAttributes.Add(traitModelConstants.GetWeaponAttributes());
                });
            }

            return Build(weaponAttributes);
        }
    }
}