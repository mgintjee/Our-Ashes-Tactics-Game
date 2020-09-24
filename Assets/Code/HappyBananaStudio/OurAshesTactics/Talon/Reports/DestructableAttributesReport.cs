/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports
{
    /// <summary>
    /// Report to display the current attributes for a specific Destructible
    /// </summary>
    public class DestructibleAttributesReport
    {
        #region Private Fields

        // The current armourPoints for the Destructible
        private readonly int currentArmourPoints = int.MinValue;

        // The current healthPoints for the Destructible
        private readonly int currentHealthPoints = int.MinValue;

        // The maximum armourPoints for the Destructible
        private readonly int maximumArmourPoints = int.MinValue;

        // The maximum healthPoints for the Destructible
        private readonly int maximumHealthPoints = int.MinValue;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="currentArmourPoints"></param>
        /// <param name="currentHealthPoints"></param>
        /// <param name="maximumArmourPoints"></param>
        /// <param name="maximumHealthPoints"></param>
        private DestructibleAttributesReport(
            int currentArmourPoints, int currentHealthPoints,
            int maximumArmourPoints, int maximumHealthPoints)
        {
            // Set the current attributes for this report
            this.currentArmourPoints = currentArmourPoints;
            this.currentHealthPoints = currentHealthPoints;
            // Set the maximum attributes for this report
            this.maximumArmourPoints = maximumArmourPoints;
            this.maximumHealthPoints = maximumHealthPoints;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Get the currentArmourPoints
        /// </summary>
        /// <returns>The int currentArmourPoints</returns>
        public int GetCurrentArmourPoints()
        {
            return this.currentArmourPoints;
        }

        /// <summary>
        /// Get the currentHealthPoints
        /// </summary>
        /// <returns>The int currentHealthPoints</returns>
        public int GetCurrentHealthPoints()
        {
            return this.currentHealthPoints;
        }

        /// <summary>
        /// Get the maximumArmourPoints
        /// </summary>
        /// <returns>The int maximumArmourPoints</returns>
        public int GetMaximumArmourPoints()
        {
            return this.maximumArmourPoints;
        }

        /// <summary>
        /// Get the maximumHealthPoints
        /// </summary>
        /// <returns>The int maximumHealthPoints</returns>
        public int GetMaximumHealthPoints()
        {
            return this.maximumHealthPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>currentArmourPoints= " + this.GetCurrentArmourPoints() +
                "\n\t>currentHealthPoints= " + this.GetCurrentHealthPoints() +
                "\n\t>maximumArmourPoints= " + this.GetMaximumArmourPoints() +
                "\n\t>maximumHealthPoints= " + this.GetMaximumHealthPoints();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // The currentArmourPoints for the Destructible
            private int currentArmourPoints = int.MinValue;

            // The currentHealthPoints for the Destructible
            private int currentHealthPoints = int.MinValue;

            // The maximumArmourPoints for the Destructible
            private int maximumArmourPoints = int.MinValue;

            // The maximumHealthPoints for the Destructible
            private int maximumHealthPoints = int.MinValue;

            // Tracks whether currentArmourPoints has been set
            private bool setCurrentArmourPoints = false;

            // Tracks whether currentHealthPoints has been set
            private bool setCurrentHealthPoints = false;

            // Tracks whether maximumArmourPoints has been set
            private bool setMaximumArmourPoints = false;

            // Tracks whether maximumHealthPoints has been set
            private bool setMaximumHealthPoints = false;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Build the DestructableAttributesReport with the set parameters
            /// </summary>
            /// <returns>The DestructableAttributesReport</returns>
            public DestructibleAttributesReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new DestructibleAttributesReport(
                        this.currentArmourPoints, this.currentHealthPoints,
                        this.maximumArmourPoints, this.maximumHealthPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Current armourPoints
            /// </summary>
            /// <param name="currentArmourPoints">The Current armourPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentArmourPoints(int currentArmourPoints)
            {
                this.currentArmourPoints = currentArmourPoints;
                this.setCurrentArmourPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Current healthPoints
            /// </summary>
            /// <param name="currentHealthPoints">The Current healthPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentHealthPoints(int currentHealthPoints)
            {
                this.currentHealthPoints = currentHealthPoints;
                this.setCurrentHealthPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum armourPoints
            /// </summary>
            /// <param name="maximumArmourPoints">The Maximum armourPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMaximumArmourPoints(int maximumArmourPoints)
            {
                this.maximumArmourPoints = maximumArmourPoints;
                this.setMaximumArmourPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum healthPoints
            /// </summary>
            /// <param name="maximumHealthPoints">The Maximum healthPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMaximumHealthPoints(int maximumHealthPoints)
            {
                this.maximumHealthPoints = maximumHealthPoints;
                this.setMaximumHealthPoints = true;
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
                // Check that currentArmourPoints has been set
                if (!this.setCurrentArmourPoints)
                {
                    argumentExceptionSet.Add("currentArmourPoints has not been set");
                }
                // Check that currentHealthPoints has been set
                if (!this.setCurrentHealthPoints)
                {
                    argumentExceptionSet.Add("currentHealthPoints has not been set");
                }
                // Check thatmaximumArmourPoints has been set
                if (!this.setMaximumArmourPoints)
                {
                    argumentExceptionSet.Add("maximumArmourPoints has not been set");
                }
                // Check that maximumHealthPoints has been set
                if (!this.setMaximumHealthPoints)
                {
                    argumentExceptionSet.Add("maximumHealthPoints has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}