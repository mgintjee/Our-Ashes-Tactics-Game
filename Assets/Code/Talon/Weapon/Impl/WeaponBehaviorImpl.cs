using System;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public class WeaponBehaviorImpl
    : WeaponBehavior
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly WeaponAttributes weaponAttributes;

    // Todo
    private readonly WeaponIdEnum weaponId;

    #endregion Private Fields

    #region Public Constructors

    public WeaponBehaviorImpl(WeaponIdEnum weaponId)
    {
        this.weaponId = weaponId;
        this.weaponAttributes = WeaponAttributeConstants.GetImplementedWeaponAttributes(weaponId);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="accuracyPenalty"></param>
    /// <param name="targetRange">    </param>
    /// <returns></returns>
    public override WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange)
    {
        // Default a null WeaponReport
        WeaponCombatOrderReport weaponReport;
        // Calculate the difference in ideal range and
        int rangeDifference = this.GetRangePoints() - targetRange;
        // Calculate the proximity bonus points for the range
        int accuracyProximityBonus = this.GetRangeProximityPoints() * rangeDifference;
        // Calculate the remaining accuracy after penalties
        int accuracyRemaining = this.GetAccuracyPoints() + accuracyProximityBonus - accuracyPenalty;
        logger.Debug("Generating WeaponReport. WeaponAccuracy=?, AccuracyProximityBonus=?, AccuracyPenalty=?, AccuracyRemaining=?",
            this.GetAccuracyPoints(), accuracyProximityBonus, accuracyPenalty, accuracyRemaining);
        int shotsHit = int.MinValue;
        // Check if the accuracy remaining makes it impossible to hit
        if (accuracyRemaining <= 0)
        {
            logger.Debug("Generating Auto-Miss WeaponReport. AccuracyDifference=? is less than or equal to 0.",
        accuracyRemaining);
            shotsHit = 0;
        }
        // Check if the accuracy remaining makes it impossible to miss
        else if (accuracyRemaining >= 100)
        {
            logger.Debug("Generating Auto-Hit WeaponReport. AccuracyDifference=? is greater than or equal to 100.",
                accuracyRemaining);
            shotsHit = this.GetShotCountPoints();
        }
        else
        {
            logger.Debug("Generating Regular WeaponReport.");
            // Calculate the accuracyRatio: accuracyRemaining / maxAccuracy
            float accuracyRatio = accuracyRemaining / 100f;
            // Default 0 shots landed
            shotsHit = 0;
            // Iterate over the number of shots
            for (int i = 0; i < this.GetShotCountPoints(); ++i)
            {
                // Collect a random float
                float randomValue = new Random().Next(0, 100);
                // Check that random float is less than the accuracyRatio
                if (randomValue <= accuracyRatio)
                {
                    // Increment the shotsLanded
                    shotsHit++;
                }
            }
        }

        // Build a WeaponReport with all shots missing
        return weaponReport = new WeaponCombatOrderReport.Builder()
            .SetDamagePerShot(this.GetDamagePoints())
            .SetPenetration(this.GetPenetrationPoints())
            .SetShotsHit(shotsHit)
            .Build();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetAccuracyPoints()
    {
        return this.weaponAttributes.GetAccuracyPoints();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetDamagePoints()
    {
        return this.weaponAttributes.GetDamagePoints();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetPenetrationPoints()
    {
        return this.weaponAttributes.GetPenetrationPoints();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetRangePoints()
    {
        return this.weaponAttributes.GetRangePoints();
    }

    public override int GetRangeProximityPoints()
    {
        return this.weaponAttributes.GetRangeProximityPoints();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override int GetShotCountPoints()
    {
        return this.weaponAttributes.GetShotCountPoints();
    }

    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    #endregion Public Methods
}