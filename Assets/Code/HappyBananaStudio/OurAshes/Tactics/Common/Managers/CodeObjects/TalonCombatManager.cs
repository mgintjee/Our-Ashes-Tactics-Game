namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Reports;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonCombatManager
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderFireReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonActionResultFireReport GetExpectedTalonActionResultFireReport(ITalonActionOrderFireReport talonActionOrderFireReport)
        {
            if (talonActionOrderFireReport != null)
            {
                ITalonObject actingTalonObject = RosterObjectManager.GetTalonObject(talonActionOrderFireReport.GetActingTalonIdentificationReport());
                ITalonObject targetTalonObject = RosterObjectManager.GetTalonObject(talonActionOrderFireReport.GetTargetTalonIdentificationReport());

                ITalonAttributesReport actingTalonAttributesReport = actingTalonObject.GetTalonInformationReport()
                    .GetTalonAttributesReport();
                ITalonAttributesReport targetTalonAttributesReport = targetTalonObject.GetTalonInformationReport()
                    .GetTalonAttributesReport();
                IList<IWeaponResultReport> weaponResultReportList = GetExpectedWeaponResultReportList(talonActionOrderFireReport.GetPathObject(),
                    actingTalonAttributesReport, targetTalonAttributesReport);
                return new TalonActionResultFireReportImpl.Builder()
                    .SetTalonActionOrderReport(talonActionOrderFireReport)
                    .SetActingTalonAttributesReport(actingTalonAttributesReport)
                    .SetTargetTalonAttributesReport(targetTalonObject.GetTalonInformationReport().GetTalonAttributesReport())
                    .SetWeaponResultReportList(weaponResultReportList)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderFireReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonActionResultFireReport GetTalonActionResultFireReport(
            ITalonActionOrderFireReport talonActionOrderFireReport)
        {
            if (talonActionOrderFireReport != null)
            {
                ITalonObject actingTalonObject = RosterObjectManager.GetTalonObject(talonActionOrderFireReport.GetActingTalonIdentificationReport());
                ITalonObject targetTalonObject = RosterObjectManager.GetTalonObject(talonActionOrderFireReport.GetTargetTalonIdentificationReport());

                ITalonAttributesReport actingTalonAttributesReport = actingTalonObject.GetTalonInformationReport()
                    .GetTalonAttributesReport();
                ITalonAttributesReport targetTalonAttributesReport = targetTalonObject.GetTalonInformationReport()
                    .GetTalonAttributesReport();
                IList<IWeaponResultReport> weaponResultReportList = GetWeaponResultReportList(talonActionOrderFireReport.GetPathObject(),
                    actingTalonAttributesReport, targetTalonAttributesReport);
                foreach (IWeaponResultReport weaponResultReport in weaponResultReportList)
                {
                    targetTalonObject.InputDamage(weaponResultReport.GetArmorDamageCaused(),
                        weaponResultReport.GetHealthDamageCaused());
                }
                return new TalonActionResultFireReportImpl.Builder()
                    .SetTalonActionOrderReport(talonActionOrderFireReport)
                    .SetActingTalonAttributesReport(actingTalonAttributesReport)
                    .SetTargetTalonAttributesReport(targetTalonObject.GetTalonInformationReport().GetTalonAttributesReport())
                    .SetWeaponResultReportList(weaponResultReportList)
                    .Build();
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectCost">
        /// </param>
        /// <param name="pathObjectLength">
        /// </param>
        /// <param name="weaponInformationReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static int GetExpectedShotsThatHit(IPathObject pathObject, IWeaponInformationReport weaponInformationReport)
        {
            int shotsThatHit = 0;
            IWeaponAttributes weaponAttributes = weaponInformationReport.GetWeaponAttributes();
            if (weaponAttributes.GetMaxRangePoints() >= pathObject.GetPathObjectLength())
            {
                int accuracyRemaining = weaponAttributes.GetAccuracyPoints() - pathObject.GetPathObjectCost();
                if (accuracyRemaining >= 100)
                {
                    shotsThatHit = weaponAttributes.GetNumberOfShots();
                }
                else if (accuracyRemaining > 0)
                {
                    shotsThatHit = Mathf.RoundToInt(weaponAttributes.GetNumberOfShots() * accuracyRemaining / 100f);
                }
            }
            return shotsThatHit;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="actingTalonAttributesReport">
        /// </param>
        /// <param name="targetTalonAttributesReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static IList<IWeaponResultReport> GetExpectedWeaponResultReportList(IPathObject pathObject,
            ITalonAttributesReport actingTalonAttributesReport, ITalonAttributesReport targetTalonAttributesReport)
        {
            IList<IWeaponResultReport> weaponResultReportList = new List<IWeaponResultReport>();
            IDestructibleAttributesReport targetDestructibleAttributesReport = targetTalonAttributesReport.GetDestructibleAttributesReport();
            foreach (IWeaponInformationReport weaponInformationReport in actingTalonAttributesReport.GetMountableAttributesReport().GetWeaponInformationReportList())
            {
                IWeaponOrderReport weaponOrderReport = new WeaponOrderReportImpl.Builder()
                        .SetShotsThatHit(GetExpectedShotsThatHit(pathObject, weaponInformationReport))
                        .SetWeaponInformationReport(weaponInformationReport)
                        .Build();

                weaponResultReportList.Add(GetWeaponResultReport(weaponOrderReport, targetDestructibleAttributesReport));
            }

            return weaponResultReportList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObjectCost">
        /// </param>
        /// <param name="pathObjectLength">
        /// </param>
        /// <param name="weaponInformationReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static int GetShotsThatHit(IPathObject pathObject, IWeaponInformationReport weaponInformationReport)
        {
            int shotsThatHit = 0;
            IWeaponAttributes weaponAttributes = weaponInformationReport.GetWeaponAttributes();
            if (weaponAttributes.GetMaxRangePoints() >= pathObject.GetPathObjectLength())
            {
                int accuracyRemaining = weaponAttributes.GetAccuracyPoints() - pathObject.GetPathObjectCost();
                if (accuracyRemaining >= 100)
                {
                    shotsThatHit = weaponAttributes.GetNumberOfShots();
                }
                else if (accuracyRemaining > 0)
                {
                    for (int i = 0; i < weaponAttributes.GetNumberOfShots(); ++i)
                    {
                        if (RandomNumberGeneratorUtil.GetNextInt(100) < accuracyRemaining)
                        {
                            shotsThatHit++;
                        }
                    }
                }
            }
            return shotsThatHit;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponOrderReport">
        /// </param>
        /// <param name="destructibleAttributesReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWeaponResultReport GetWeaponResultReport(IWeaponOrderReport weaponOrderReport, IDestructibleAttributesReport destructibleAttributesReport)
        {
            IWeaponAttributes weaponAttributes = weaponOrderReport.GetWeaponInformationReport().GetWeaponAttributes();
            int armor = destructibleAttributesReport.GetCurrentArmorPoints();
            int armorRemaining = armor - weaponAttributes.GetPenetrationPoints();
            if (armorRemaining < 0)
            {
                armorRemaining = 0;
            }
            int damageRemaining = weaponAttributes.GetDamagePoints() - armorRemaining;
            if (damageRemaining <= 0)
            {
                damageRemaining = Mathf.CeilToInt(weaponAttributes.GetNumberOfShots() / 2f);
            }
            return new WeaponResultReportImpl.Builder()
                    .SetHealthDamageCaused(damageRemaining)
                    .SetArmorDamageCaused(0)
                    .SetWeaponOrderReport(weaponOrderReport)
                    .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="actingTalonAttributesReport">
        /// </param>
        /// <param name="targetTalonAttributesReport">
        /// </param>
        /// <returns>
        /// </returns>
        private static IList<IWeaponResultReport> GetWeaponResultReportList(IPathObject pathObject,
            ITalonAttributesReport actingTalonAttributesReport, ITalonAttributesReport targetTalonAttributesReport)
        {
            IList<IWeaponResultReport> weaponResultReportList = new List<IWeaponResultReport>();
            IDestructibleAttributesReport targetDestructibleAttributesReport = targetTalonAttributesReport.GetDestructibleAttributesReport();
            foreach (IWeaponInformationReport weaponInformationReport in actingTalonAttributesReport.GetMountableAttributesReport().GetWeaponInformationReportList())
            {
                IWeaponOrderReport weaponOrderReport = new WeaponOrderReportImpl.Builder()
                        .SetShotsThatHit(GetShotsThatHit(pathObject, weaponInformationReport))
                        .SetWeaponInformationReport(weaponInformationReport)
                        .Build();

                weaponResultReportList.Add(GetWeaponResultReport(weaponOrderReport, targetDestructibleAttributesReport));
            }

            return weaponResultReportList;
        }
    }
}