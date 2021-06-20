using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.Sizes.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Utils.Strings;
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
        private readonly GearSize _armorGearSize;

        // Todo
        private readonly GearSize _cabinGearSize;

        // Todo
        private readonly GearSize _engineGearSize;

        // Todo
        private readonly IList<GearSize> _weaponGearSizes;

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
            this._armorGearSize = armorGearSize;
            this._cabinGearSize = cabinGearSize;
            this._engineGearSize = engineGearSize;
            this._weaponGearSizes = weaponGearSizes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string weaponStrings = (_weaponGearSizes.Count != 0)
                ? string.Join(", ", _weaponGearSizes) : "empty";
            return string.Format("{0}: Armor: {1}, Cabin: {2}, Engine: {3}, Weapons: {4}",
                this.GetType().Name,
                StringUtils.Format(typeof(GearSize), _armorGearSize),
                StringUtils.Format(typeof(GearSize), _cabinGearSize),
                StringUtils.Format(typeof(GearSize), _engineGearSize),
                StringUtils.Format(typeof(GearSize), weaponStrings));
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetArmorGearSize()
        {
            return this._armorGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetCabinGearSize()
        {
            return this._cabinGearSize;
        }

        /// <inheritdoc/>
        GearSize ILoadoutAttributes.GetEngineGearSize()
        {
            return this._engineGearSize;
        }

        /// <inheritdoc/>
        IList<GearSize> ILoadoutAttributes.GetWeaponGearSizes()
        {
            return new List<GearSize>(this._weaponGearSizes);
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