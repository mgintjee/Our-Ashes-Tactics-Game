using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Attributes.Impl;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Attributes.Impl
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct LoadoutAttributes
        : ILoadoutAttributes
    {
        // Todo
        private readonly IArmorAttributes armorAttributes;

        // Todo
        private readonly IEngineAttributes engineAttributes;

        // Todo
        private readonly IWeaponAttributes weaponAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorAttributes"></param>
        /// <param name="engineAttributes"></param>
        /// <param name="weaponAttributes"></param>
        private LoadoutAttributes(IArmorAttributes armorAttributes,
            IEngineAttributes engineAttributes, IWeaponAttributes weaponAttributes)
        {
            this.armorAttributes = armorAttributes;
            this.engineAttributes = engineAttributes;
            this.weaponAttributes = weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IArmorAttributes ILoadoutAttributes.GetArmorAttributes()
        {
            return this.armorAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngineAttributes ILoadoutAttributes.GetEngineAttributes()
        {
            return this.engineAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWeaponAttributes ILoadoutAttributes.GetWeaponAttributes()
        {
            return this.weaponAttributes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t\t>{1}" +
                "\n\t\t>{2}" +
                "\n\t\t>{3}",
                this.GetType().Name, this.armorAttributes,
                this.engineAttributes, this.weaponAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IArmorAttributes armorAttributes = new ArmorAttributes.Builder().Build();

            // Todo
            private IEngineAttributes engineAttributes = new EngineAttributes.Builder().Build();

            // Todo
            private IWeaponAttributes weaponAttributes = new WeaponAttributes.Builder().Build();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutAttributes Build()
            {
                // Instantiate a new Report
                return new LoadoutAttributes(this.armorAttributes, this.engineAttributes, this.weaponAttributes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutAttributes Build(ISet<ILoadoutAttributes> loadoutAttributesSet)
            {
                // Default an empty list
                ISet<IArmorAttributes> armorAttributesSet = new HashSet<IArmorAttributes>();
                // Default an empty list
                ISet<IEngineAttributes> engineAttributesSet = new HashSet<IEngineAttributes>();
                // Default an empty list
                ISet<IWeaponAttributes> weaponAttributesSet = new HashSet<IWeaponAttributes>();
                // Iterate over the attributes
                foreach (ILoadoutAttributes loadoutAttributes in loadoutAttributesSet)
                {
                    armorAttributesSet.Add(loadoutAttributes.GetArmorAttributes());
                    engineAttributesSet.Add(loadoutAttributes.GetEngineAttributes());
                    weaponAttributesSet.Add(loadoutAttributes.GetWeaponAttributes());
                }

                this.armorAttributes = new ArmorAttributes.Builder().Build(armorAttributesSet);
                this.engineAttributes = new EngineAttributes.Builder().Build(engineAttributesSet);
                this.weaponAttributes = new WeaponAttributes.Builder().Build(weaponAttributesSet);

                // Instantiate a new Report
                return new LoadoutAttributes(this.armorAttributes, this.engineAttributes, this.weaponAttributes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorAttributes"></param>
            public Builder SetArmorAttributes(IArmorAttributes armorAttributes)
            {
                this.armorAttributes = armorAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="engineAttributes"></param>
            public Builder SetEngineAttributes(IEngineAttributes engineAttributes)
            {
                this.engineAttributes = engineAttributes;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponAttributes"></param>
            public Builder SetWeaponAttributes(IWeaponAttributes weaponAttributes)
            {
                this.weaponAttributes = weaponAttributes;
                return this;
            }
        }
    }
}