namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct LoadoutAttributesImpl
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
        private LoadoutAttributesImpl(IArmorAttributes armorAttributes, IEngineAttributes engineAttributes, IWeaponAttributes weaponAttributes)
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IArmorAttributes armorAttributes = new ArmorAttributesImpl.Builder().Build();

            // Todo
            private IEngineAttributes engineAttributes = new EngineAttributesImpl.Builder().Build();

            // Todo
            private IWeaponAttributes weaponAttributes = new WeaponAttributesImpl.Builder().Build();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutAttributes Build()
            {
                    // Instantiate a new Report
                    return new LoadoutAttributesImpl(this.armorAttributes, this.engineAttributes, this.weaponAttributes);
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