using System;
using System.Diagnostics;

/// <summary>
/// Weapon Behvaior Impl
/// </summary>
public class WeaponBehaviorImpl
    : WeaponBehavior
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly WeaponAttributes weaponAttributes = null;
    private readonly WeaponIdEnum weaponId = WeaponIdEnum.NULL;

    #endregion Private Fields

    #region Public Constructors

    public WeaponBehaviorImpl(WeaponIdEnum weaponId)
    {
        if (weaponId != WeaponIdEnum.NULL)
        {
            this.weaponId = weaponId;
            this.weaponAttributes = WeaponAttributeConstants.GetImplementedWeaponAttributes(weaponId);
        }
        else
        {
            throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                "\n\t>" + typeof(WeaponIdEnum) + " is null");
        }
    }

    #endregion Public Constructors

    #region Public Methods

    public override WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange)
    {
        int accuracyRemaining = this.CalculateRemainingAccuracy(accuracyPenalty, targetRange);
        int numberOfShots;
        // Check if the accuracy remaining makes it impossible to hit
        if (accuracyRemaining <= 0)
        {
            logger.Debug("Generating Auto-Miss WeaponReport. AccuracyDifference=? is less than or equal to 0.",
        accuracyRemaining);
            numberOfShots = 0;
        }
        // Check if the accuracy remaining makes it impossible to miss
        else if (accuracyRemaining >= 100)
        {
            logger.Debug("Generating Auto-Hit WeaponReport. AccuracyDifference=? is greater than or equal to 100.",
                accuracyRemaining);
            numberOfShots = this.GetWeaponAttributes().GetNumberOfShots();
        }
        else
        {
            logger.Debug("Generating Regular WeaponReport.");
            // Calculate the accuracyRatio: accuracyRemaining / maxAccuracy
            float accuracyRatio = accuracyRemaining / 100f;
            // Default 0 shots landed
            numberOfShots = 0;
            // Iterate over the number of shots
            for (int i = 0; i < this.GetWeaponAttributes().GetNumberOfShots(); ++i)
            {
                // Collect a random float
                float randomValue = RandomNumberGeneratorUtil.GetNextFloat();
                logger.Debug("?/?", randomValue, accuracyRatio);
                // Check that random float is less than the accuracyRatio
                if (randomValue <= accuracyRatio)
                {
                    logger.Debug("Hit!");
                    // Increment the numberOfShots
                    numberOfShots++;
                }
            }
            logger.Debug("Generating Regular WeaponReport. NumberOfShots=?/?", numberOfShots, this.GetWeaponAttributes().GetNumberOfShots());
        }

        // Build a WeaponReport with all shots that hit
        return new WeaponCombatOrderReport.Builder()
            .SetDamagePerShot(this.GetWeaponAttributes().GetDamagePoints())
            .SetNumberOfShots(numberOfShots)
            .SetPenetration(this.GetWeaponAttributes().GetPenetrationPoints())
            .Build();
    }

    public override int GetMaxAccuracyPenalty(int targetRange)
    {
        return this.CalculateRemainingAccuracy(0, targetRange);
    }

    public override WeaponAttributes GetWeaponAttributes()
    {
        return this.weaponAttributes;
    }

    public override WeaponIdEnum GetWeaponId()
    {
        return this.weaponId;
    }

    #endregion Public Methods

    #region Private Methods

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