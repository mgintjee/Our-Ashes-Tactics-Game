namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.Hoplites.Construction
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Hoplites;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Hoplites.Reports;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomHopliteConstructionReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IHopliteConstructionReport GenerateRandomAiHopliteConstructionReport()
        {
            return new HopliteConstructionReportImpl.Builder()
                .SetControllerId(GetRandomNonHumanControllerId())
                .SetHopliteTraitSet(GetRandomHopliteTraitSet())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IHopliteConstructionReport GenerateRandomHumanHopliteConstructionReport()
        {
            return new HopliteConstructionReportImpl.Builder()
                .SetControllerId(ControllerType.Human)
                .SetHopliteTraitSet(GetRandomHopliteTraitSet())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static HopliteTraitEnum GetRandomHopliteTrait()
        {
            Array enumValues = Enum.GetValues(typeof(HopliteTraitEnum));
            return (HopliteTraitEnum)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static ISet<HopliteTraitEnum> GetRandomHopliteTraitSet()
        {
            ISet<HopliteTraitEnum> hopliteTraitSet = new HashSet<HopliteTraitEnum>();
            int hopliteTraitCount = RandomNumberGeneratorUtil.GetNextInt(1, Enum.GetValues(typeof(HopliteTraitEnum)).Length);
            while (hopliteTraitSet.Count < hopliteTraitCount)
            {
                hopliteTraitSet.Add(GetRandomHopliteTrait());
            }
            return hopliteTraitSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static ControllerType GetRandomNonHumanControllerId()
        {
            Array enumValues = Enum.GetValues(typeof(ControllerType));
            ControllerType controllerId = (ControllerType)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
            return (controllerId.Equals(ControllerType.Human))
                ? GetRandomNonHumanControllerId()
                : controllerId;
        }
    }
}
