/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Logging;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.RandomNumberGenerator;
using System;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Impl
{
    /// <summary>
    /// Weapon Behvaior Impl
    /// </summary>
    public class WeaponBehaviorImpl
    : IWeaponBehavior
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

        private readonly WeaponAttributes weaponAttributes = null;
        private readonly WeaponIdEnum weaponId = WeaponIdEnum.NULL;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        public WeaponBehaviorImpl(WeaponIdEnum weaponId)
        {
            if (weaponId != WeaponIdEnum.NULL)
            {
                this.weaponId = weaponId;
                this.weaponAttributes = WeaponAttributesConstants.GetImplementedWeaponAttributes(weaponId);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(WeaponIdEnum) + " is null");
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty"></param>
        /// <param name="targetRange">    </param>
        /// <returns></returns>
        public WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange)
        {
            int accuracyRemaining = this.CalculateRemainingAccuracy(accuracyPenalty, targetRange);
            int numberOfShots;
            // Check if the accuracy remaining makes it impossible to hit
            if (accuracyRemaining <= 0)
            {
                logger.Debug("Generating Auto-Miss ?. accuracyRemaining=? is less than or equal to 0.",
                    typeof(WeaponCombatOrderReport), accuracyRemaining);
                numberOfShots = 0;
            }
            // Check if the accuracy remaining makes it impossible to miss
            else if (accuracyRemaining >= 100)
            {
                logger.Debug("Generating Auto-Hit ?. accuracyRemaining=? is greater than or equal to 100.",
                    typeof(WeaponCombatOrderReport), accuracyRemaining);
                numberOfShots = this.GetWeaponAttributes().GetNumberOfShots();
            }
            else
            {
                // Default 0 numberOfShots
                numberOfShots = 0;
                // Iterate over the number of shots
                for (int i = 0; i < this.GetWeaponAttributes().GetNumberOfShots(); ++i)
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
                    typeof(WeaponCombatOrderReport), accuracyRemaining, numberOfShots, this.GetWeaponAttributes().GetNumberOfShots());
            }

            // Build a WeaponReport with all shots that hit
            return new WeaponCombatOrderReport.Builder()
                .SetDamagePerShot(this.GetWeaponAttributes().GetDamagePoints())
                .SetNumberOfShots(numberOfShots)
                .SetPenetration(this.GetWeaponAttributes().GetPenetrationPoints())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange"></param>
        /// <returns></returns>
        public int GetMaxAccuracyPenalty(int targetRange)
        {
            return this.CalculateRemainingAccuracy(0, targetRange);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponAttributes GetWeaponAttributes()
        {
            return this.weaponAttributes;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public WeaponIdEnum GetWeaponId()
        {
            return this.weaponId;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty"></param>
        /// <param name="targetRange">    </param>
        /// <returns></returns>
        private int CalculateRemainingAccuracy(int accuracyPenalty, int targetRange)
        {
            // Calculate the difference in ideal range and
            int rangeDifference = this.GetWeaponAttributes().GetRangePoints() - targetRange;
            // Calculate the proximity bonus points for the range
            int accuracyProximityBonus = this.GetWeaponAttributes().GetRangeProximityPoints() * rangeDifference;
            // Calculate the remaining accuracy after penalties
            int accuracyRemaining = this.GetWeaponAttributes().GetAccuracyPoints() + accuracyProximityBonus - accuracyPenalty;
            return accuracyRemaining;
        }

        #endregion Private Methods
    }
}