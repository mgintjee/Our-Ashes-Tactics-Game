/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.RandomNumberGenerators;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Weapons
{
    /// <summary>
    /// Weapon Behavior Impl
    /// </summary>
    public class WeaponBehaviorImpl
    : IWeaponBehavior
    {
        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        private readonly IWeaponAttributes weaponAttributes = null;
        private readonly WeaponModelIdEnum weaponId = WeaponModelIdEnum.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        public WeaponBehaviorImpl(WeaponModelIdEnum weaponId)
        {
            if (weaponId != WeaponModelIdEnum.None)
            {
                this.weaponId = weaponId;
                this.weaponAttributes = WeaponAttributesConstants.GetAttributes(weaponId);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. " +
                    "\n\t> ? is invalid", this.GetType(), typeof(WeaponModelIdEnum));
            }
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
        public IWeaponOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange)
        {
            int accuracyRemaining = this.CalculateRemainingAccuracy(accuracyPenalty, targetRange);
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
                numberOfShots = this.weaponAttributes.GetNumberOfShots();
            }
            else
            {
                // Default 0 numberOfShots
                numberOfShots = 0;
                // Iterate over the number of shots
                for (int i = 0; i < this.weaponAttributes.GetNumberOfShots(); ++i)
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
                    typeof(IWeaponOrderReport), accuracyRemaining, numberOfShots, this.weaponAttributes.GetNumberOfShots());
            }

            // Build a WeaponReport with all shots that hit
            return ReportBuilder.Weapon.Order.GetBuilder()
                .SetShotsThatHit(numberOfShots)
                .SetWeaponInformationReport(this.GetWeaponInformationReport())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        public int GetMaxAccuracyPenalty(int targetRange)
        {
            return this.CalculateRemainingAccuracy(0, targetRange);
        }

        public IWeaponInformationReport GetWeaponInformationReport()
        {
            return ReportBuilder.Weapon.Information.GetBuilder()
                .SetWeaponId(this.weaponId)
                .SetWeaponAttributes(this.weaponAttributes)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>

        public override string ToString()
        {
            return this.GetWeaponInformationReport().ToString();
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
        private int CalculateRemainingAccuracy(int accuracyPenalty, int targetRange)
        {
            // Calculate the difference in ideal range and
            int rangeDifference = this.weaponAttributes.GetRangePoints() - targetRange;
            // Calculate the proximity bonus points for the range
            int accuracyProximityBonus = this.weaponAttributes.GetRangeProximityPoints() * rangeDifference;
            // Calculate the remaining accuracy after penalties
            int accuracyRemaining = this.weaponAttributes.GetAccuracyPoints() + accuracyProximityBonus - accuracyPenalty;
            return accuracyRemaining;
        }
    }
}