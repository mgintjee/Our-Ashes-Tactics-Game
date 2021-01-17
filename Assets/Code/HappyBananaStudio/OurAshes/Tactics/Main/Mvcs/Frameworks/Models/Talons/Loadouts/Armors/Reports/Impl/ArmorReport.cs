namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ArmorReport
        : IArmorReport
    {
        // Todo
        private readonly ArmorId armorId;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly IArmorTraitReport armorTraitReport;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorId"></param>
        /// <param name="armorTraitReport"></param>
        private ArmorReport(ArmorId armorId, IArmorTraitReport armorTraitReport)
        {
            this.armorId = armorId;
            this.loadoutRarity = ArmorRarityConstants.GetLoadoutRarity(this.armorId);
            this.armorTraitReport = armorTraitReport;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                ArmorTraitConstants.Materials.GetLoadoutAttributes(this.armorTraitReport.GetArmorTraitMaterial()),
                ArmorTraitConstants.Structures.GetLoadoutAttributes(this.armorTraitReport.GetArmorTraitStructure()),
                ArmorIdConstants.GetLoadoutAttributes(this.armorId)
            };
            this.loadoutAttributes = new LoadoutAttributes.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        ArmorId IArmorReport.GetArmorId()
        {
            return this.armorId;
        }

        /// <inheritdoc/>
        IArmorTraitReport IArmorReport.GetArmorTraitReport()
        {
            return this.armorTraitReport;
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
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}" +
                "\n\t>{5}" +
                "\n\t>{6}",
                this.GetType().Name, typeof(ArmorId).Name, this.armorId,
                typeof(LoadoutRarity).Name, this.loadoutRarity,
                this.armorTraitReport, this.loadoutAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ArmorId armorId = ArmorId.None;

            // Todo
            private IArmorTraitReport armorTraitReport = new ArmorTraitReport.Builder().Build();

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IArmorReport Build()
            {
                // Collect the invalid reasons to be built
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new ArmorReport(this.armorId, this.armorTraitReport);
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
            /// <param name="armorId"></param>
            public Builder SetArmorId(ArmorId armorId)
            {
                this.armorId = armorId;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorTraitReport"></param>
            public Builder SetArmorTraitReport(IArmorTraitReport armorTraitReport)
            {
                this.armorTraitReport = armorTraitReport;
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
                // Check that armorId has been set
                if (this.armorId == ArmorId.None)
                {
                    argumentExceptionSet.Add(typeof(ArmorId).Name + " cannot be None.");
                }
                // Check that armorTraitReport has been set
                if (this.armorTraitReport == null)
                {
                    argumentExceptionSet.Add(typeof(IArmorTraitReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}