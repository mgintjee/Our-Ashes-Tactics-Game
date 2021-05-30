using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Implementations
{
    /// <summary>
    /// Loadout Attributes Implementation
    /// </summary>
    public struct LoadoutAttributes
        : ILoadoutAttributes
    {
        // Todo
        private readonly GearSize armorGearSize;

        // Todo
        private readonly GearSize cabinGearSize;

        // Todo
        private readonly GearSize engineGearSize;

        // Todo
        private readonly IList<GearSize> weaponGearSizes;

        /// <summary>
        /// Tododw
        /// </summary>
        /// <param name="armorGearSize">  </param>
        /// <param name="cabinGearSize">  </param>
        /// <param name="engineGearSize"> </param>
        /// <param name="weaponGearSizes"></param>
        private LoadoutAttributes(GearSize armorGearSize, GearSize cabinGearSize,
            GearSize engineGearSize, IList<GearSize> weaponGearSizes)
        {
            this.armorGearSize = armorGearSize;
            this.cabinGearSize = cabinGearSize;
            this.engineGearSize = engineGearSize;
            this.weaponGearSizes = weaponGearSizes;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetArmorGearSize()
        {
            return this.armorGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetCabinGearSize()
        {
            return this.cabinGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetEngineGearSize()
        {
            return this.engineGearSize;
        }

        /// <inheritdoc/>
        IList<GearSize> ILoadoutAttributes.GetWeaponGearSizes()
        {
            return new List<GearSize>(this.weaponGearSizes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private GearSize armorGearSize = GearSize.None;

            // Todo
            private GearSize cabinGearSize = GearSize.None;

            // Todo
            private GearSize engineGearSize = GearSize.None;

            // Todo
            private IList<GearSize> weaponGearSizes = new List<GearSize>();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ILoadoutAttributes Build()
            {
                // Instantiate a new attributes
                return new LoadoutAttributes(this.armorGearSize, this.cabinGearSize, this.engineGearSize, this.weaponGearSizes);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetArmorGearSize(GearSize gearSize)
            {
                this.armorGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetCabinGearSize(GearSize gearSize)
            {
                this.cabinGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSize"></param>
            public Builder SetEngineGearSize(GearSize gearSize)
            {
                this.engineGearSize = gearSize;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gearSizes"></param>
            public Builder SetWeaponGearSizes(IList<GearSize> gearSizes)
            {
                this.weaponGearSizes = new List<GearSize>(gearSizes);
                return this;
            }
        }
    }
}