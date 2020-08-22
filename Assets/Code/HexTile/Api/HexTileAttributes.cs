using System;
using System.Collections.Generic;

/// <summary>
/// Object to store the numerical attributes of a HexTile
/// </summary>
public class HexTileAttributes
{
    #region Private Fields

    // The fireCost for the HexTile
    private readonly int fireCost;

    // The moveCost for the HexTile
    private readonly int moveCost;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Private constructor to force using the Builder
    /// </summary>
    /// <param name="fireCost">The fireCost to set</param>
    /// <param name="moveCost">The moveCost to set</param>
    private HexTileAttributes(int fireCost, int moveCost)
    {
        this.fireCost = fireCost;
        this.moveCost = moveCost;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// Get the fireCost
    /// </summary>
    /// <returns>The int fireCost</returns>
    public int GetFireCost()
    {
        return this.fireCost;
    }

    /// <summary>
    /// Get the moveCost
    /// </summary>
    /// <returns>The int moveCost</returns>
    public int GetMoveCost()
    {
        return this.moveCost;
    }

    public override string ToString()
    {
        return this.GetType() + ": fireCost: " + this.GetFireCost() + ", moveCost: " + this.GetMoveCost();
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Builder class for this report
    /// </summary>
    public class Builder
    {
        #region Private Fields

        // The fireCost for the HexTile
        private int fireCost = int.MinValue;

        // The moveCost for the HexTile
        private int moveCost = int.MinValue;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Build the HexTileAttributes with the set parameters
        /// </summary>
        /// <returns>The HexTileAttributes</returns>
        public HexTileAttributes Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new HexTileAttributes(this.fireCost, this.moveCost);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n", invalidReasons));
            }
        }

        /// <summary>
        /// Set the value of the fireCost
        /// </summary>
        /// <param name="fireCost">The fireCost to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetFireCost(int fireCost)
        {
            this.fireCost = fireCost;
            return this;
        }

        /// <summary>
        /// Set the value of the moveCost
        /// </summary>
        /// <param name="moveCost">The moveCost to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetMoveCost(int moveCost)
        {
            this.moveCost = moveCost;
            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private HashSet<string> IsValid()
        {
            // Default an empty Set: String
            HashSet<string> argumentExceptionSet = new HashSet<string>();
            // Check that fireCost has been set and valid
            if (this.fireCost < 0)
            {
                argumentExceptionSet.Add("fireCost=" + this.fireCost + " is not valid.");
            }
            // Check that fireCost has been set and valid
            if (this.moveCost < 0)
            {
                argumentExceptionSet.Add("moveCost=" + this.moveCost + " is not valid.");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}