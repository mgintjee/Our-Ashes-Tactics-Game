using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Mounts.Weapons.Traits.Reports.Impl
{
    /// <summary>
    /// Weapon Trait Report Impl
    /// </summary>
    public class WeaponTraitReport
        : IWeaponTraitReport
    {
        // Todo
        private readonly WeaponTraitAmmo weaponTraitAmmo;

        // Todo
        private readonly WeaponTraitBarrel weaponTraitBarrel;

        // Todo
        private readonly WeaponTraitMagazine weaponTraitMagazine;

        // Todo
        private readonly WeaponTraitTargeting weaponTraitTargeting;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponTraitAmmo"></param>
        /// <param name="weaponTraitBarrel"></param>
        /// <param name="weaponTraitMagazine"></param>
        /// <param name="weaponTraitTargeting"></param>
        private WeaponTraitReport(WeaponTraitAmmo weaponTraitAmmo, WeaponTraitBarrel weaponTraitBarrel,
            WeaponTraitMagazine weaponTraitMagazine, WeaponTraitTargeting weaponTraitTargeting)
        {
            this.weaponTraitAmmo = weaponTraitAmmo;
            this.weaponTraitBarrel = weaponTraitBarrel;
            this.weaponTraitMagazine = weaponTraitMagazine;
            this.weaponTraitTargeting = weaponTraitTargeting;
        }

        /// <inheritdoc/>
        WeaponTraitAmmo IWeaponTraitReport.GetWeaponTraitAmmo()
        {
            return this.weaponTraitAmmo;
        }

        /// <inheritdoc/>
        WeaponTraitBarrel IWeaponTraitReport.GetWeaponTraitBarrel()
        {
            return this.weaponTraitBarrel;
        }

        /// <inheritdoc/>
        WeaponTraitMagazine IWeaponTraitReport.GetWeaponTraitMagazine()
        {
            return this.weaponTraitMagazine;
        }

        /// <inheritdoc/>
        WeaponTraitTargeting IWeaponTraitReport.GetWeaponTraitTargeting()
        {
            return this.weaponTraitTargeting;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}, {5}={6}, {7}={8}",
                this.GetType().Name, typeof(WeaponTraitAmmo).Name, this.weaponTraitAmmo,
                typeof(WeaponTraitBarrel).Name, this.weaponTraitBarrel, typeof(WeaponTraitMagazine).Name,
                this.weaponTraitMagazine, typeof(WeaponTraitTargeting).Name, this.weaponTraitTargeting);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private WeaponTraitAmmo weaponTraitAmmo = WeaponTraitAmmo.None;

            // Todo
            private WeaponTraitBarrel weaponTraitBarrel = WeaponTraitBarrel.None;

            // Todo
            private WeaponTraitMagazine weaponTraitMagazine = WeaponTraitMagazine.None;

            // Todo
            private WeaponTraitTargeting weaponTraitTargeting = WeaponTraitTargeting.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IWeaponTraitReport Build()
            {
                // Instantiate a new Report
                return new WeaponTraitReport(this.weaponTraitAmmo, this.weaponTraitBarrel,
                    this.weaponTraitMagazine, this.weaponTraitTargeting);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitAmmo"></param>
            public Builder SetWeaponTraitAmmo(WeaponTraitAmmo weaponTraitAmmo)
            {
                this.weaponTraitAmmo = weaponTraitAmmo;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitBarrel"></param>
            public Builder SetWeaponTraitBarrel(WeaponTraitBarrel weaponTraitBarrel)
            {
                this.weaponTraitBarrel = weaponTraitBarrel;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitMagazine"></param>
            public Builder SetWeaponTraitMagazine(WeaponTraitMagazine weaponTraitMagazine)
            {
                this.weaponTraitMagazine = weaponTraitMagazine;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitTargeting"></param>
            public Builder SetWeaponTraitTargeting(WeaponTraitTargeting weaponTraitTargeting)
            {
                this.weaponTraitTargeting = weaponTraitTargeting;
                return this;
            }
        }
    }
}