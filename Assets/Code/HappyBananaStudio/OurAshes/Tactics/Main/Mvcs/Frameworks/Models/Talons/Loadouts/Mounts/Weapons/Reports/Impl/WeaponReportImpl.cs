namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponReportImpl
        : IWeaponReport
    {
        // Todo
        private readonly WeaponId weaponId;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly WeaponType weaponType;

        // Todo
        private readonly MountSize mountSize;

        // Todo
        private readonly WeaponTraitAmmo weaponTraitAmmo;

        // Todo
        private readonly WeaponTraitBarrel weaponTraitBarrel;

        // Todo
        private readonly WeaponTraitMagazine weaponTraitMagazine;

        // Todo
        private readonly WeaponTraitTargeting weaponTraitTargeting;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <param name="weaponTraitAmmo"></param>
        /// <param name="weaponTraitBarrel"></param>
        /// <param name="weaponTraitMagazine"></param>
        /// <param name="weaponTraitTargeting"></param>
        private WeaponReportImpl(WeaponId weaponId, WeaponTraitAmmo weaponTraitAmmo, WeaponTraitBarrel weaponTraitBarrel,
            WeaponTraitMagazine weaponTraitMagazine, WeaponTraitTargeting weaponTraitTargeting)
        {
            this.weaponId = weaponId;
            this.loadoutRarity = WeaponRarityConstants.GetLoadoutRarity(this.weaponId);
            this.weaponType = WeaponTypeConstants.GetWeaponType(this.weaponId);
            this.mountSize = WeaponMountSizeConstants.GetMountSize(this.weaponId);
            this.weaponTraitAmmo = weaponTraitAmmo;
            this.weaponTraitBarrel = weaponTraitBarrel;
            this.weaponTraitMagazine = weaponTraitMagazine;
            this.weaponTraitTargeting = weaponTraitTargeting;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                WeaponTraitConstants.Ammo.GetLoadoutAttributes(this.weaponTraitAmmo),
                WeaponTraitConstants.Barrel.GetLoadoutAttributes(this.weaponTraitBarrel),
                WeaponTraitConstants.Magazine.GetLoadoutAttributes(this.weaponTraitMagazine),
                WeaponTraitConstants.Targeting.GetLoadoutAttributes(this.weaponTraitTargeting),
                WeaponIdConstants.GetLoadoutAttributes(this.weaponId)
            };
            this.loadoutAttributes = new LoadoutAttributesImpl.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        ILoadoutAttributes ILoadoutReport.GetLoadoutAttributes()
        {
            return this.loadoutAttributes;
        }

        /// <inheritdoc/>
        LoadoutRarity ILoadoutReport.GetLoadoutRarity()
        {
            return this.loadoutRarity;
        }

        /// <inheritdoc/>
        MountSize IMountReport.GetMountSize()
        {
            return this.mountSize;
        }

        /// <inheritdoc/>
        WeaponId IWeaponReport.GetWeaponId()
        {
            return this.weaponId;
        }

        /// <inheritdoc/>
        WeaponTraitAmmo IWeaponReport.GetWeaponTraitAmmo()
        {
            return this.weaponTraitAmmo;
        }

        /// <inheritdoc/>
        WeaponTraitBarrel IWeaponReport.GetWeaponTraitBarrel()
        {
            return this.weaponTraitBarrel;
        }

        /// <inheritdoc/>
        WeaponTraitMagazine IWeaponReport.GetWeaponTraitMagazine()
        {
            return this.weaponTraitMagazine;
        }

        /// <inheritdoc/>
        WeaponTraitTargeting IWeaponReport.GetWeaponTraitTargeting()
        {
            return this.weaponTraitTargeting;
        }

        /// <inheritdoc/>
        WeaponType IWeaponReport.GetWeaponType()
        {
            return this.weaponType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private WeaponId weaponId = WeaponId.None;

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
            public IWeaponReport Build()
            {
                // Collect the invalid reasons to be built
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new WeaponReportImpl(this.weaponId, this.weaponTraitAmmo,
                        this.weaponTraitBarrel, this.weaponTraitMagazine, this.weaponTraitTargeting);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponId"></param>
            public Builder SetWeaponId(WeaponId weaponId)
            {
                this.weaponId = weaponId;
                return this;
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

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that weaponId has been set
                if (this.weaponId == WeaponId.None)
                {
                    argumentExceptionSet.Add(typeof(WeaponId).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}