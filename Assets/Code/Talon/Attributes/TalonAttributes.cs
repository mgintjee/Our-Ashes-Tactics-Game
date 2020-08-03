using System;

/// <summary>
/// Object to store the numerical attributes of a Talon
/// </summary>
public class TalonAttributes
{
    #region Private Fields

    // The armourPoints for the Talon
    private readonly int armourPoints;

    // The healthPoints for the Talon
    private readonly int healthPoints;

    // The movePoints for the Talon
    private readonly int movePoints;

    // The turnPoints for the Talon
    private readonly int turnPoints;

    // The weaponPoints for the Talon
    private readonly int weaponPoints;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Private constructor to force using the Builder
    /// </summary>
    /// <param name="armourPoints">The armourPoints to set</param>
    /// <param name="healthPoints">The healthPoints to set</param>
    /// <param name="turnPoints">  The turnPoints to set</param>
    /// <param name="movePoints">  The movePoints to set</param>
    /// <param name="weaponPoints">The weaponPoints to set</param>
    private TalonAttributes(int armourPoints, int healthPoints, int turnPoints, int movePoints, int weaponPoints)
    {
        this.armourPoints = armourPoints;
        this.healthPoints = healthPoints;
        this.turnPoints = turnPoints;
        this.movePoints = movePoints;
        this.weaponPoints = weaponPoints;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Get the armourPoints
    /// </summary>
    /// <returns>The int armourPoints</returns>
    public int GetArmourPoints()
    {
        return this.armourPoints;
    }

    /// <summary>
    /// Get the healthPoints
    /// </summary>
    /// <returns>The int healthPoints</returns>

    public int GetHealthPoints()
    {
        return this.healthPoints;
    }

    /// <summary>
    /// Get the movePoints
    /// </summary>
    /// <returns>The int movePoints</returns>
    public int GetMovePoints()
    {
        return this.movePoints;
    }

    /// <summary>
    /// Get the turnPoints
    /// </summary>
    /// <returns>The int turnPoints</returns>
    public int GetTurnPoints()
    {
        return this.turnPoints;
    }

    /// <summary>
    /// Get the weaponPoints
    /// </summary>
    /// <returns>The int weaponPoints</returns>
    public int GetWeaponPoints()
    {
        return this.weaponPoints;
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Builder class for this report
    /// </summary>
    public class Builder
    {
        #region Private Fields

        // Default the parameters to int.MinValue
        private int armourPoints = int.MinValue;

        private int healthPoints = int.MinValue;
        private int movePoints = int.MinValue;
        private int turnPoints = int.MinValue;
        private int weaponPoints = int.MinValue;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Build the TalonAttributes with the set parameters
        /// </summary>
        /// <returns>The TalonAttributes</returns>
        public TalonAttributes Build()
        {
            // Check that the set parameters are valid
            if (this.IsValid())
            {
                // Instantiate a new Report
                return new TalonAttributes(this.armourPoints, this.healthPoints, this.turnPoints, this.movePoints, this.weaponPoints);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n>armourPoints: " + this.armourPoints +
                    "\n>healthPoints: " + this.healthPoints +
                    "\n>turnPoints: " + this.turnPoints +
                    "\n>movePoints: " + this.movePoints +
                    "\n>weaponPoints: " + this.weaponPoints);
            }
        }

        /// <summary>
        /// Set the value of the armourPoints
        /// </summary>
        /// <param name="armourPoints">The armourPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetArmourPoints(int armourPoints)
        {
            this.armourPoints = armourPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the healthPoints
        /// </summary>
        /// <param name="healthPoints">The healthPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetHealthPoints(int healthPoints)
        {
            this.healthPoints = healthPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the movePoints
        /// </summary>
        /// <param name="movePoints">The movePoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetMovePoints(int movePoints)
        {
            this.movePoints = movePoints;
            return this;
        }

        /// <summary>
        /// Set the value of the turnPoints
        /// </summary>
        /// <param name="turnPoints">The turnPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetTurnPoints(int turnPoints)
        {
            this.turnPoints = turnPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the weaponPoints
        /// </summary>
        /// <param name="weaponPoints">The weaponPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetWeaponPoints(int weaponPoints)
        {
            this.weaponPoints = weaponPoints;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Check that the parameters for this report are valid
        /// </summary>
        /// <returns>True if this report is valid and ready to be built. False otherwise</returns>
        private bool IsValid()
        {
            // Check that the parameters have been set
            return this.healthPoints != int.MinValue &&
                this.healthPoints != int.MinValue &&
                this.turnPoints != int.MinValue &&
                this.movePoints != int.MinValue &&
                this.weaponPoints != int.MinValue;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}