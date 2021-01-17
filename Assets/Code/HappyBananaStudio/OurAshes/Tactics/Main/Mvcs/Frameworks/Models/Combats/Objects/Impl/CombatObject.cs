namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Roe Object Class
    /// </summary>
    public class CombatObject
        : ICombatObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <inheritdoc/>
        IList<ICombatReport> ICombatObject.GetActualCombatReport(TalonCallSign actingTalonCallSign,
            TalonCallSign targetTalonCallSign, float accuracyCost)
        {
            ITalonObject actingTalonObject = RosterManager.GetTalonObject(actingTalonCallSign);
            ITalonObject targetTalonObject = RosterManager.GetTalonObject(targetTalonCallSign);
            IList<ICombatReport> combatReportList = new List<ICombatReport>();
            IList<IMountReport> mountReportList = actingTalonObject.GetTalonReport()
                .GetTalonLoadoutReport().GetMountReportList();
            ITalonAttributesReport targetTalonAttributesReport = targetTalonObject.GetTalonReport()
                .GetCurrentTalonAttributesReport();

            foreach (IMountReport mountReport in mountReportList)
            {
                ICombatReport combatReport = new CombatReport.Builder().Build();
                if (mountReport is IWeaponReport weaponReport)
                {
                    logger.Debug("Determining actual ? for ?", typeof(ICombatReport), weaponReport);
                    IWeaponAttributes weaponAttributes = weaponReport.GetLoadoutAttributes().GetWeaponAttributes();
                    combatReport = this.GetCombatReport(
                        this.GetActualVolleyLanded(weaponAttributes, accuracyCost),
                        weaponAttributes, targetTalonAttributesReport);
                    logger.Debug("Actual ?", combatReport);
                }
                combatReportList.Add(combatReport);
            }

            return combatReportList;
        }

        /// <inheritdoc/>
        IList<ICombatReport> ICombatObject.GetAverageCombatReport(TalonCallSign actingTalonCallSign,
            TalonCallSign targetTalonCallSign, float accuracyCost)
        {
            ITalonObject actingTalonObject = RosterManager.GetTalonObject(actingTalonCallSign);
            ITalonObject targetTalonObject = RosterManager.GetTalonObject(targetTalonCallSign);
            IList<ICombatReport> combatReportList = new List<ICombatReport>();
            IList<IMountReport> mountReportList = actingTalonObject.GetTalonReport()
                .GetTalonLoadoutReport().GetMountReportList();
            ITalonAttributesReport targetTalonAttributesReport = targetTalonObject.GetTalonReport()
                .GetCurrentTalonAttributesReport();

            foreach (IMountReport mountReport in mountReportList)
            {
                ICombatReport combatReport = new CombatReport.Builder().Build();
                if (mountReport is IWeaponReport weaponReport)
                {
                    logger.Debug("Determining average ? for ?", typeof(ICombatReport), weaponReport);
                    IWeaponAttributes weaponAttributes = weaponReport.GetLoadoutAttributes().GetWeaponAttributes();
                    combatReport = this.GetCombatReport(
                        this.GetAverageVolleyLanded(weaponAttributes, accuracyCost),
                        weaponAttributes, targetTalonAttributesReport);
                    logger.Debug("Average ?", combatReport);
                }
                combatReportList.Add(combatReport);
            }

            return combatReportList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributes"></param>
        /// <param name="accuracyCost"></param>
        /// <returns></returns>
        private int GetActualVolleyLanded(IWeaponAttributes weaponAttributes, float accuracyCost)
        {
            float accuracyRemaining = weaponAttributes.GetAccuracyPoints() - accuracyCost;
            int volleyLanded = 0;
            if (accuracyRemaining > 100)
            {
                volleyLanded = weaponAttributes.GetVolleySize();
            }
            else if (accuracyRemaining > 0)
            {
                for (int i = 0; i < weaponAttributes.GetVolleySize(); ++i)
                {
                    float randomAccuracy = (float)(RandomNumberGeneratorUtil.GetNextDouble() * 100);
                    if (randomAccuracy < accuracyRemaining)
                    {
                        volleyLanded++;
                    }
                }
            }
            logger.Debug("For accuracyRemaining=?, Actual volleyLanded=?, Expected volleyLanded=?",
                accuracyRemaining, volleyLanded, this.GetAverageVolleyLanded(weaponAttributes, accuracyCost));
            return volleyLanded;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributes"></param>
        /// <param name="accuracyCost"></param>
        /// <returns></returns>
        private int GetAverageVolleyLanded(IWeaponAttributes weaponAttributes, float accuracyCost)
        {
            return (int) Math.Round(weaponAttributes.GetVolleySize() *
                ((weaponAttributes.GetAccuracyPoints() - accuracyCost) / 100f));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="volleyLanded"></param>
        /// <param name="weaponAttributes"></param>
        /// <param name="targetTalonAttributesReport"></param>
        /// <returns></returns>
        private ICombatReport GetCombatReport(int volleyLanded, IWeaponAttributes weaponAttributes,
            ITalonAttributesReport targetTalonAttributesReport)
        {
            float armorEffect = volleyLanded * (weaponAttributes.GetArmorDamagePoints());
            float healthEffect = volleyLanded;
            if (weaponAttributes.GetArmorPenetrationPoints() > targetTalonAttributesReport.GetArmorPoints())
            {
                healthEffect *= weaponAttributes.GetHealthDamagePoints();
            }
            else
            {
                float healthFactor = weaponAttributes.GetHealthDamagePoints() - targetTalonAttributesReport.GetArmorPoints();
                if (healthFactor <= 0)
                {
                    healthFactor = 0.5f;
                }
                healthEffect *= healthFactor;
            }
            ITalonEffectObject talonEffectObject = new TalonEffectObject.Builder()
                .SetArmorEffect(-armorEffect)
                .SetHealthEffect(-healthEffect)
                .Build();
            logger.Debug("?", talonEffectObject);
            return new CombatReport.Builder()
                .SetTalonEffectObjectSet(new HashSet<ITalonEffectObject>() { talonEffectObject })
                .Build();
        }
    }
}