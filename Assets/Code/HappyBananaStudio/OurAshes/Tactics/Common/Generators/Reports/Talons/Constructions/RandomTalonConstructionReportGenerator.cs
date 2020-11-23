namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.Talons.Constructions
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Hoplites.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Customization;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Utilities;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Constuction;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Information;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomTalonConstructionReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ITalonConstructionReport GenerateRandomAiTalonConstructionReport(
            FactionId factionId, PhalanxId phalanxId,
            CallSign callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            TalonModelId talonModelId = GetRandomTalonModelId();
            ITalonIdentificationReport talonIdentificationReport = new TalonIdentificationReportImpl.Builder()
                .SetCallSign(callSign)
                .SetFactionId(factionId)
                .SetPhalanxId(phalanxId)
                .SetTalonModelId(talonModelId)
                .Build();
            return GenerateRandomTalonConstructionReport(talonIdentificationReport, talonCustomizationReport, talonModelId,
                RandomHopliteConstructionReportGenerator.GenerateRandomAiHopliteConstructionReport());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ITalonConstructionReport GenerateRandomHumanTalonConstructionReport(
            FactionId factionId, PhalanxId phalanxId,
            CallSign callSign, ITalonCustomizationReport talonCustomizationReport)
        {
            TalonModelId talonModelId = GetRandomTalonModelId();
            ITalonIdentificationReport talonIdentificationReport = new TalonIdentificationReportImpl.Builder()
                .SetCallSign(callSign)
                .SetFactionId(factionId)
                .SetPhalanxId(phalanxId)
                .SetTalonModelId(talonModelId)
                .Build();
            return GenerateRandomTalonConstructionReport(talonIdentificationReport, talonCustomizationReport, talonModelId,
                RandomHopliteConstructionReportGenerator.GenerateRandomHumanHopliteConstructionReport());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="talonCustomizationReport">
        /// </param>
        /// <param name="talonModelId">
        /// </param>
        /// <param name="hopliteConstructionReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static ITalonConstructionReport GenerateRandomTalonConstructionReport(
            ITalonIdentificationReport talonIdentificationReport, ITalonCustomizationReport talonCustomizationReport,
            TalonModelId talonModelId, IHopliteConstructionReport hopliteConstructionReport)
        {
            return new TalonConstructionReportImpl.Builder()
                .SetHopliteConstructionReport(hopliteConstructionReport)
                .SetTalonCustomizationReport(talonCustomizationReport)
                .SetTalonIdentificationReport(talonIdentificationReport)
                .SetUtilityList(GetRandomUtilityModelIdList(talonModelId))
                .SetWeaponIdList(GetRandomWeaponModelIdList(talonModelId))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static TalonModelId GetRandomTalonModelId()
        {
            Array enumValues = Enum.GetValues(typeof(TalonModelId));
            return (TalonModelId)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static UtilityModelId GetRandomUtilityModelId()
        {
            Array enumValues = Enum.GetValues(typeof(UtilityModelId));
            return (UtilityModelId)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IList<UtilityModelId> GetRandomUtilityModelIdList(TalonModelId talonModelId)
        {
            int utilityPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetUtilityMountPoints();
            IList<UtilityModelId> utilityModelIdList = new List<UtilityModelId>();

            for (int i = 0; i < utilityPoints; ++i)
            {
                utilityModelIdList.Add(GetRandomUtilityModelId());
            }
            return utilityModelIdList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static WeaponModelId GetRandomWeaponModelId()
        {
            Array enumValues = Enum.GetValues(typeof(WeaponModelId));
            return (WeaponModelId)enumValues.GetValue(RandomNumberGeneratorUtil.GetNextInt(1, enumValues.Length));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IList<WeaponModelId> GetRandomWeaponModelIdList(TalonModelId talonModelId)
        {
            int weaponPoints = TalonAttributesConstants.GetAttributes(talonModelId).GetMountableAttributes().GetWeaponMountPoints();

            IList<WeaponModelId> utilityModelIdList = new List<WeaponModelId>();
            for (int i = 0; i < weaponPoints; ++i)
            {
                utilityModelIdList.Add(GetRandomWeaponModelId());
            }
            return utilityModelIdList;
        }
    }
}