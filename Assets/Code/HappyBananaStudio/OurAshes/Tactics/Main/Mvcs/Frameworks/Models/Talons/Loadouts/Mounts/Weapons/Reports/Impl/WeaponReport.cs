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
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct WeaponReport
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
        private readonly IWeaponTraitReport weaponTraitReport;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <param name="weaponTraitReport"></param>
        private WeaponReport(WeaponId weaponId, IWeaponTraitReport weaponTraitReport)
        {
            this.weaponId = weaponId;
            this.loadoutRarity = WeaponRarityConstants.GetLoadoutRarity(this.weaponId);
            this.weaponType = WeaponTypeConstants.GetWeaponType(this.weaponId);
            this.mountSize = WeaponMountSizeConstants.GetMountSize(this.weaponId);
            this.weaponTraitReport = weaponTraitReport;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                WeaponTraitConstants.Ammo.GetLoadoutAttributes(this.weaponTraitReport.GetWeaponTraitAmmo()),
                WeaponTraitConstants.Barrel.GetLoadoutAttributes(this.weaponTraitReport.GetWeaponTraitBarrel()),
                WeaponTraitConstants.Magazine.GetLoadoutAttributes(this.weaponTraitReport.GetWeaponTraitMagazine()),
                WeaponTraitConstants.Targeting.GetLoadoutAttributes(this.weaponTraitReport.GetWeaponTraitTargeting()),
                WeaponIdConstants.GetLoadoutAttributes(this.weaponId)
            };
            this.loadoutAttributes = new LoadoutAttributes.Builder().Build(loadoutAttributesSet);
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
        WeaponType IWeaponReport.GetWeaponType()
        {
            return this.weaponType;
        }

        /// <inheritdoc/>
        IWeaponTraitReport IWeaponReport.GetWeaponTraitReport()
        {
            return this.weaponTraitReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}, {5}={6}, " +
                "\n\t>{7}" +
                "\n\t>{8}",
                this.GetType().Name, typeof(WeaponId).Name, this.weaponId,
                typeof(LoadoutRarity).Name, this.loadoutRarity,
                typeof(MountSize).Name, this.mountSize,
                this.weaponTraitReport, this.loadoutAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private WeaponId weaponId = WeaponId.None;

            // Todo
            private IWeaponTraitReport weaponTraitReport;

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
                    return new WeaponReport(this.weaponId, this.weaponTraitReport);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
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
            /// <param name="weaponTraitReport"></param>
            public Builder SetWeaponTraitReport(IWeaponTraitReport weaponTraitReport)
            {
                this.weaponTraitReport = weaponTraitReport;
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
                // Check that weaponTraitReport has been set
                if (this.weaponTraitReport == null)
                {
                    argumentExceptionSet.Add(typeof(IWeaponTraitReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}