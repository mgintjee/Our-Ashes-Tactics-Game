namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;

    /// <summary>
    /// Armor Trait Report Impl
    /// </summary>
    public class ArmorTraitReport
        : IArmorTraitReport
    {
        // Todo
        private readonly ArmorTraitStructure armorTraitStructure;

        // Todo
        private readonly ArmorTraitMaterial armorTraitMaterial;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorTraitStructure"></param>
        /// <param name="armorTraitMaterial"></param>
        private ArmorTraitReport(ArmorTraitStructure armorTraitStructure, ArmorTraitMaterial armorTraitMaterial)
        {
            this.armorTraitStructure = armorTraitStructure;
            this.armorTraitMaterial = armorTraitMaterial;
        }

        /// <inheritdoc/>
        ArmorTraitMaterial IArmorTraitReport.GetArmorTraitMaterial()
        {
            return this.armorTraitMaterial;
        }

        /// <inheritdoc/>
        ArmorTraitStructure IArmorTraitReport.GetArmorTraitStructure()
        {
            return this.armorTraitStructure;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}, {3}={4}",
                this.GetType().Name, typeof(ArmorTraitMaterial).Name, this.armorTraitStructure,
                typeof(ArmorTraitStructure).Name, this.armorTraitMaterial);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ArmorTraitStructure armorTraitStructure = ArmorTraitStructure.None;

            // Todo
            private ArmorTraitMaterial armorTraitMaterial = ArmorTraitMaterial.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IArmorTraitReport Build()
            {
                // Instantiate a new Report
                return new ArmorTraitReport(this.armorTraitStructure, this.armorTraitMaterial);
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
            /// <param name="armorTraitMaterial"></param>
            public Builder SetArmorTraitMaterial(ArmorTraitMaterial armorTraitMaterial)
            {
                this.armorTraitMaterial = armorTraitMaterial;
                return this;
            }
        }
    }
}