/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Paths.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshesTactics.Impl.Reports.Weapons;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        /// <param name="pathObjectFire">
        /// </param>
        /// <param name="weaponInformationReportList">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonActionResultFireReport GetTalonCombatOrderReport(IPathObject pathObjectFire,
            ITalonActionOrderFireReport talonActionOrderFireReport,
            IList<IWeaponInformationReport> weaponInformationReportList)
        {
            /*
            if (pathObjectFire != null &&
                weaponInformationReportList != null)
            {
                IList<IWeaponOrderReport> weaponCombatOrderList = new List<IWeaponOrderReport>();

                return ReportBuilder.Talon.Combat.Order.GetBuilder()
                    .SetWeaponOrderReportList(weaponCombatOrderList)
                    .Build();
            }
            else
            {
            }

            if (pathObjectFire != null)
            {
                logger.Debug("Firing with: [?]", string.Join(", ", this.weaponBehaviorList));
                // Iterate over the List: WeaponBehavior
                foreach (IWeaponBehavior weaponBehavior in this.weaponBehaviorList)
                {
                    // Collect the weaponCombatOrder from the weaponBehavior
                    IWeaponOrderReport weaponCombatOrder = weaponBehavior.GenerateWeaponReport(
                        pathObjectFire.GetPathObjectCost(),
                        pathObjectFire.GetPathObjectLength());
                    logger.Debug("Added ?", weaponCombatOrder);
                    // Add the generated weaponCombatOrder to the list
                    weaponCombatOrderList.Add(weaponCombatOrder);
                }
            }
            */
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponAttributes">
        /// </param>
        /// <param name="accuracyPenalty">
        /// </param>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        private static int CalculateRemainingAccuracy(IWeaponAttributes weaponAttributes, int accuracyPenalty, int targetRange)
        {
            // Calculate the difference in ideal range and
            int rangeDifference = weaponAttributes.GetMaxRangePoints() - targetRange;
            // Calculate the remaining accuracy after penalties
            int accuracyRemaining = weaponAttributes.GetAccuracyPoints() - accuracyPenalty;
            return accuracyRemaining;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty">
        /// </param>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWeaponOrderReport GenerateWeaponReport(IWeaponInformationReport weaponInformationReport, int accuracyPenalty, int targetRange)
        {
            int accuracyRemaining = CalculateRemainingAccuracy(weaponInformationReport.GetWeaponAttributes(), accuracyPenalty, targetRange);
            int numberOfShots;
            // Check if the accuracy remaining makes it impossible to hit
            if (accuracyRemaining <= 0)
            {
                logger.Debug("Generating Auto-Miss ?. accuracyRemaining=? is less than or equal to 0.",
                    typeof(IWeaponOrderReport), accuracyRemaining);
                numberOfShots = 0;
            }
            // Check if the accuracy remaining makes it impossible to miss
            else if (accuracyRemaining >= 100)
            {
                logger.Debug("Generating Auto-Hit ?. accuracyRemaining=? is greater than or equal to 100.",
                    typeof(IWeaponOrderReport), accuracyRemaining);
                numberOfShots = weaponInformationReport.GetWeaponAttributes().GetNumberOfShots();
            }
            else
            {
                // Default 0 numberOfShots
                numberOfShots = 0;
                // Iterate over the number of shots
                for (int i = 0; i < weaponInformationReport.GetWeaponAttributes().GetNumberOfShots(); ++i)
                {
                    // Todo: Think about using the Fire Emblems style of RNG here? Check if the
                    // accuracyRemaining is less than the next random int
                    if (accuracyRemaining < RandomNumberGeneratorUtil.GetNextInt(100))
                    {
                        // Increment the numberOfShots
                        numberOfShots++;
                    }
                }
                logger.Debug("Generating Regular ?. accuracyRemaining=?, numberOfShots=?/?",
                    typeof(IWeaponOrderReport), accuracyRemaining, numberOfShots, weaponInformationReport.GetWeaponAttributes().GetNumberOfShots());
            }

            // Build a WeaponReport with all shots that hit
            return new WeaponOrderReportImpl.Builder()
                .SetShotsThatHit(numberOfShots)
                .SetWeaponInformationReport(weaponInformationReport)
                .Build();
        }
    }
}
