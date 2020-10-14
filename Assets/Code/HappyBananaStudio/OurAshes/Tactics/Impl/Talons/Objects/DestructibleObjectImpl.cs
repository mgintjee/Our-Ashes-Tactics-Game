

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Hoplites.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Utilities.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// Destructible Object Impl
    /// </summary>
    public class DestructibleObjectImpl
        : IDestructibleObject
    {
        // Todo
        private readonly IDestructibleAttributes destructibleAttributes = null;

        // Todo
        private int armorPoints = int.MinValue;

        // Todo
        private int healthPoints = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleAttributes">
        /// </param>
        public DestructibleObjectImpl(ITalonConstructionReport talonConstructionReport)
        {
            this.destructibleAttributes = new DestructibleAttributesImpl.Builder()
                .SetDestrucibleAttributesCollection(new HashSet<IDestructibleAttributes>()
                    {
                        // Add the base TalonModelId DestructibleAttributes
                        TalonAttributesConstants.GetAttributes(
                            talonConstructionReport.GetTalonIdentificationReport().GetTalonModelId())
                            .GetDestructibleAttributes(),
                        // Add the Hoplite Bonus DestructibleAttributes
                        HopliteAttributesConstants.GetAttributes(
                            talonConstructionReport.GetHopliteConstructionReport().GetHopliteTraitSet())
                            .GetDestructibleAttributes(),
                        // Add the Utility Bonus DestructibleAttributes
                        UtilityAttributesConstants.GetAttributes(
                            new HashSet<UtilityModelIdEnum>(talonConstructionReport.GetUtilityModelIdList()))
                            .GetDestructibleAttributes()
                    }
                )
                .Build();

            this.armorPoints = this.destructibleAttributes.GetArmorPoints();
            this.healthPoints = this.destructibleAttributes.GetHealthPoints();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributesReport IDestructibleObject.GetDestructibleAttributesReport()
        {
            return new DestructibleAttributesReportImpl.Builder()
                .SetCurrentArmourPoints(this.armorPoints)
                .SetCurrentHealthPoints(this.healthPoints)
                .SetMaximumArmourPoints(this.destructibleAttributes.GetArmorPoints())
                .SetMaximumHealthPoints(this.destructibleAttributes.GetHealthPoints())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="armorDamage">
        /// </param>
        /// <param name="healthDamage">
        /// </param>
        void IDestructibleObject.InputDamage(int armorDamage, int healthDamage)
        {
            this.armorPoints -= armorDamage;
            this.healthPoints -= healthDamage;
        }
    }
}
