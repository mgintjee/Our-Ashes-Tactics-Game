using System;
using System.Collections.Generic;

/// <summary>
/// </summary>
public class WeaponAttributes
{
    #region Private Fields

    // Todo
    private readonly int accuracyPoints;

    // Todo
    private readonly int damagePoints;

    // Todo
    private readonly int penetrationPoints;

    // Todo
    private readonly int rangePoints;

    // Todo
    private readonly int rangeProximityPoints;

    // Todo
    private readonly int shotCountPoints;

    #endregion Private Fields

    #region Private Constructors

    /// <summary>
    /// Private constructor to force using the Builder
    /// </summary>
    /// <param name="accuracyPoints">      The accuracyPoints to set</param>
    /// <param name="damagePoints">        The damagePoints to set</param>
    /// <param name="penetrationPoints">   The penetrationPoints to set</param>
    /// <param name="rangePoints">         The rangePoints to set</param>
    /// <param name="rangeProximityPoints">The rangeProximityPoints to set</param>
    /// <param name="shotCountPoints">     The shotCountPoints to set</param>
    private WeaponAttributes(int accuracyPoints, int damagePoints, int penetrationPoints, int rangePoints, int rangeProximityPoints, int shotCountPoints)
    {
        this.accuracyPoints = accuracyPoints;
        this.damagePoints = damagePoints;
        this.penetrationPoints = penetrationPoints;
        this.rangePoints = rangePoints;
        this.rangeProximityPoints = rangeProximityPoints;
        this.shotCountPoints = shotCountPoints;
    }

    #endregion Private Constructors

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetAccuracyPoints()
    {
        return this.accuracyPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetDamagePoints()
    {
        return this.damagePoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetPenetrationPoints()
    {
        return this.penetrationPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetRangePoints()
    {
        return this.rangePoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetRangeProximityPoints()
    {
        return this.rangeProximityPoints;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public int GetShotCountPoints()
    {
        return this.shotCountPoints;
    }

    #endregion Public Methods

    #region Public Classes

    /// <summary>
    /// Todo
    /// </summary>
    public class Builder
    {
        #region Protected Fields

        // Todo
        protected int accuracyPoints = int.MinValue;

        // Todo
        protected int damagePoints = int.MinValue;

        // Todo
        protected int penetrationPoints = int.MinValue;

        // Todo
        protected int rangePoints = int.MinValue;

        // Todo
        protected int rangeProximityPoints = int.MinValue;

        // Todo
        protected int shotCountPoints = int.MinValue;

        #endregion Protected Fields

        #region Public Methods

        /// <summary>
        /// Build the WeaponAttributes with the set parameters
        /// </summary>
        /// <returns>The WeaponAttributes</returns>
        public WeaponAttributes Build()
        {
            HashSet<string> invalidReasons = this.IsValid();
            // Check that the set parameters are valid
            if (invalidReasons.Count == 0)
            {
                // Instantiate a new Report
                return new WeaponAttributes(this.accuracyPoints, this.damagePoints, this.penetrationPoints,
                    this.rangePoints, this.rangeProximityPoints, this.shotCountPoints);
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    string.Join("\n>", invalidReasons));
            }
        }

        /// <summary>
        /// Set the value of the accuracyPoints
        /// </summary>
        /// <param name="accuracyPoints">The accuracyPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetAccuracyPoints(int accuracyPoints)
        {
            this.accuracyPoints = accuracyPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the damagePoints
        /// </summary>
        /// <param name="damagePoints">The damagePoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetDamagePoints(int damagePoints)
        {
            this.damagePoints = damagePoints;
            return this;
        }

        /// <summary>
        /// Set the value of the penetrationPoints
        /// </summary>
        /// <param name="penetrationPoints">The penetrationPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetPenetrationPoints(int penetrationPoints)
        {
            this.penetrationPoints = penetrationPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the rangePoints
        /// </summary>
        /// <param name="rangePoints">The rangePoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetRangePoints(int rangePoints)
        {
            this.rangePoints = rangePoints;
            return this;
        }

        /// <summary>
        /// Set the value of the rangeProximityPoints
        /// </summary>
        /// <param name="rangeProximityPoints">The rangeProximityPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetRangeProximityPoints(int rangeProximityPoints)
        {
            this.rangeProximityPoints = rangeProximityPoints;
            return this;
        }

        /// <summary>
        /// Set the value of the shotCountPoints
        /// </summary>
        /// <param name="shotCountPoints">The shotCountPoints to set</param>
        /// <returns>The Builder to continue building with</returns>
        public Builder SetShotCountPoints(int shotCountPoints)
        {
            this.shotCountPoints = shotCountPoints;
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
            // Check that accuracyPoints has been set
            if (this.accuracyPoints < 0)
            {
                argumentExceptionSet.Add("accuracyPoints=" + this.accuracyPoints + " is not valid");
            }
            // Check that damagePoints has been set
            if (this.damagePoints < 0)
            {
                argumentExceptionSet.Add("damagePoints=" + this.damagePoints + " is not valid");
            }
            // Check that penetrationPoints has been set
            if (this.penetrationPoints < 0)
            {
                argumentExceptionSet.Add("penetrationPoints=" + this.penetrationPoints + " is not valid");
            }
            // Check that rangePoints has been set
            if (this.rangePoints < 0)
            {
                argumentExceptionSet.Add("rangePoints=" + this.rangePoints + " is not valid");
            }
            // Check that rangeProximityPoints has been set
            if (this.rangeProximityPoints < 0)
            {
                argumentExceptionSet.Add("rangeProximityPoints=" + this.rangeProximityPoints + " is not valid");
            }
            // Check that shotCountPoints has been set
            if (this.shotCountPoints < 0)
            {
                argumentExceptionSet.Add("shotCountPoints=" + this.shotCountPoints + " is not valid");
            }
            return argumentExceptionSet;
        }

        #endregion Private Methods
    }

    #endregion Public Classes
}