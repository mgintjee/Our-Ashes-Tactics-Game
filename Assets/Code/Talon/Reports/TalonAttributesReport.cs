using System;
using System.Collections.Generic;

/// <summary>
/// Report to display the current attibutes for a specific Talon
/// </summary>
public class TalonAttributesReport
{
    #region Private Fields

    // The current armourPoints for the Talon
    private readonly int armourPoints;

    // The current healthPoints for the Talon
    private readonly int healthPoints;

    // The current movePoints for the Talon
    private readonly int movePoints;

    // The current orderPoints for the Talon
    private readonly int orderPoints;

    // The current turnPoints for the Talon
    private readonly int turnPoints;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Private constructor to force using the Builder
    /// </summary>
    /// <param name="armourPoints">The armourPoints to set</param>
    /// <param name="healthPoints">The healthPoints to set</param>
    /// <param name="turnPoints">  The turnPoints to set</param>
    /// <param name="movePoints">  The movePoints to set</param>
    /// <param name="orderPoints"> The movePoints to set</param>
    private TalonAttributesReport(int armourPoints, int healthPoints, int turnPoints, int movePoints, int orderPoints)
    {
        this.armourPoints = armourPoints;
        this.healthPoints = healthPoints;
        this.turnPoints = turnPoints;
        this.movePoints = movePoints;
        this.orderPoints = orderPoints;
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
    /// Get the orderPoints
    /// </summary>
    /// <returns>The int orderPoints</returns>
    public int GetOrderPoints()
    {
        return this.orderPoints;
    }

    /// <summary>
    /// Get the turnPoints
    /// </summary>
    /// <returns>The int turnPoints</returns>
    public int GetTurnPoints()
    {
        return this.turnPoints;
    }

    public override string ToString()
    {
        return this.GetType() + ":" +
            "\n\t>armourPoints= " + this.GetArmourPoints() +
            "\n\t>healthPoints= " + this.GetHealthPoints() +
            "\n\t>turnPoints= " + this.GetTurnPoints() +
            "\n\t>movePoints= " + this.GetMovePoints() +
            "\n\t>orderPoints= " + this.GetOrderPoints();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Builder class for this report
    /// </summary>
    public class Builder
    {
        #region Private Fields

        // Default the armourPoints to int.MinValue
        private int armourPoints = int.MinValue;

        // Default the healthPoints to int.MinValue
        private int healthPoints = int.MinValue;

        // Default the movePoints to int.MinValue
        private int movePoints = int.MinValue;

        // Default the orderPoints to int.MinValue
        private int orderPoints = int.MinValue;

        // Default the turnPoints to int.MinValue
        private int turnPoints = int.MinValue;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Build the TalonAttributesReport with the set parameters
        /// </summary>
        /// <returns>The TalonAttributesReport</returns>
        public TalonAttributesReport Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new TalonAttributesReport(this.armourPoints, this.healthPoints, this.turnPoints, this.movePoints, this.orderPoints);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
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
        /// Set the value of the orderPoints
        /// </summary>
        /// <param name="movePoints">The orderPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetOrderPoints(int orderPoints)
        {
            this.orderPoints = orderPoints;
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

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that armourPoints has been set
            if (this.armourPoints == int.MinValue)
            {
                argumentExceptionSet.Add("armourPoints has not been set");
            }
            // Check that healthPoints has been set
            if (this.healthPoints == int.MinValue)
            {
                argumentExceptionSet.Add("healthPoints has not been set");
            }
            // Check that turnPoints has been set
            if (this.turnPoints == int.MinValue)
            {
                argumentExceptionSet.Add("turnPoints has not been set");
            }
            // Check that movePoints has been set
            if (this.movePoints == int.MinValue)
            {
                argumentExceptionSet.Add("movePoints has not been set");
            }
            // Check that orderPoints has been set
            if (this.orderPoints == int.MinValue)
            {
                argumentExceptionSet.Add("orderPoints has not been set");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}