namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct ArmorReportImpl
        : IArmorReport
    {
        // Todo
        private readonly ArmorId armorId;

        // Todo
        private readonly LoadoutRarity loadoutRarity;

        // Todo
        private readonly ArmorTraitMaterial armorTraitMaterial;

        // Todo
        private readonly ArmorTraitStructure armorTraitStructure;

        // Todo
        private readonly ILoadoutAttributes loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorId"></param>
        /// <param name="armorTraitMaterial"></param>
        /// <param name="armorTraitStructure"></param>
        private ArmorReportImpl(ArmorId armorId, ArmorTraitMaterial armorTraitMaterial, ArmorTraitStructure armorTraitStructure)
        {
            this.armorId = armorId;
            this.loadoutRarity = ArmorRarityConstants.GetLoadoutRarity(this.armorId);
            this.armorTraitMaterial = armorTraitMaterial;
            this.armorTraitStructure = armorTraitStructure;
            ISet<ILoadoutAttributes> loadoutAttributesSet = new HashSet<ILoadoutAttributes>()
            {
                ArmorTraitConstants.Materials.GetLoadoutAttributes(this.armorTraitMaterial),
                ArmorTraitConstants.Structures.GetLoadoutAttributes(this.armorTraitStructure),
                ArmorIdConstants.GetLoadoutAttributes(this.armorId)
            };
            this.loadoutAttributes = new LoadoutAttributesImpl.Builder().Build(loadoutAttributesSet);
        }

        /// <inheritdoc/>
        ArmorId IArmorReport.GetArmorId()
        {
            return this.armorId;
        }

        /// <inheritdoc/>
        ArmorTraitMaterial IArmorReport.GetArmorTraitMaterial()
        {
            return this.armorTraitMaterial;
        }

        /// <inheritdoc/>
        ArmorTraitStructure IArmorReport.GetArmorTraitStructure()
        {
            return this.armorTraitStructure;
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ArmorId armorId = ArmorId.None;

            // Todo
            private ArmorTraitMaterial armorTraitMaterial = ArmorTraitMaterial.None;

            // Todo
            private ArmorTraitStructure armorTraitStructure = ArmorTraitStructure.None;

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
                    return new ArmorReportImpl(this.armorId, this.armorTraitMaterial, this.armorTraitStructure);
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
            /// <param name="armorTraitMaterial"></param>
            public Builder SetArmorTraitMaterial(ArmorTraitMaterial armorTraitMaterial)
            {
                this.armorTraitMaterial = armorTraitMaterial;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="armorTraitStructure"></param>
            public Builder SetArmorTraitStructure(ArmorTraitStructure armorTraitStructure)
            {
                this.armorTraitStructure = armorTraitStructure;
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
                    argumentExceptionSet.Add(typeof(ArmorId).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}