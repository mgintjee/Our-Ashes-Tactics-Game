/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Report to display the current attibutes for a specific Talon
    /// </summary>
    public class TalonAttributesReport
    {
        #region Private Fields

        // The current armourPoints for the Talon
        private readonly int currentArmourPoints = int.MinValue;

        // The current healthPoints for the Talon
        private readonly int currentHealthPoints = int.MinValue;

        // The current movePoints for the Talon
        private readonly int currentMovePoints = int.MinValue;

        // The current orderPoints for the Talon
        private readonly int currentOrderPoints = int.MinValue;

        // The current turnPoints for the Talon
        private readonly int currentTurnPoints = int.MinValue;

        // The maximum armourPoints for the Talon
        private readonly int maximumArmourPoints = int.MinValue;

        // The maximum healthPoints for the Talon
        private readonly int maximumHealthPoints = int.MinValue;

        // The maximum movePoints for the Talon
        private readonly int maximumMovePoints = int.MinValue;

        // The maximum orderPoints for the Talon
        private readonly int maximumOrderPoints = int.MinValue;

        // The maximum turnPoints for the Talon
        private readonly int maximumTurnPoints = int.MinValue;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="currentArmourPoints"></param>
        /// <param name="currentHealthPoints"></param>
        /// <param name="currentMovePoints">  </param>
        /// <param name="currentOrderPoints"> </param>
        /// <param name="currentTurnPoints">  </param>
        /// <param name="maximumArmourPoints"></param>
        /// <param name="maximumHealthPoints"></param>
        /// <param name="maximumMovePoints">  </param>
        /// <param name="maximumOrderPoints"> </param>
        /// <param name="maximumTurnPoints">  </param>
        private TalonAttributesReport(int currentArmourPoints, int currentHealthPoints,
            int currentMovePoints, int currentOrderPoints, int currentTurnPoints,
            int maximumArmourPoints, int maximumHealthPoints, int maximumMovePoints,
            int maximumOrderPoints, int maximumTurnPoints)
        {
            // Set the current attributes for this report
            this.currentArmourPoints = currentArmourPoints;
            this.currentHealthPoints = currentHealthPoints;
            this.currentMovePoints = currentMovePoints;
            this.currentOrderPoints = currentOrderPoints;
            this.currentTurnPoints = currentTurnPoints;
            // Set the maximum attributes for this report
            this.maximumArmourPoints = maximumArmourPoints;
            this.maximumHealthPoints = maximumHealthPoints;
            this.maximumMovePoints = maximumMovePoints;
            this.maximumOrderPoints = maximumOrderPoints;
            this.maximumTurnPoints = maximumTurnPoints;
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
        /// Get the currentMovePoints
        /// </summary>
        /// <returns>The int currentMovePoints</returns>
        public int GetCurrentMovePoints()
        {
            return this.currentMovePoints;
        }

        /// <summary>
        /// Get the currentOrderPoints
        /// </summary>
        /// <returns>The int currentOrderPoints</returns>
        public int GetCurrentOrderPoints()
        {
            return this.currentOrderPoints;
        }

        /// <summary>
        /// Get the currentTurnPoints
        /// </summary>
        /// <returns>The int currentTurnPoints</returns>
        public int GetCurrentTurnPoints()
        {
            return this.currentTurnPoints;
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
        /// Get the maximumMovePoints
        /// </summary>
        /// <returns>The int maximumMovePoints</returns>
        public int GetMaximumMovePoints()
        {
            return this.maximumMovePoints;
        }

        /// <summary>
        /// Get the maximumOrderPoints
        /// </summary>
        /// <returns>The int maximumOrderPoints</returns>
        public int GetMaximumOrderPoints()
        {
            return this.maximumOrderPoints;
        }

        /// <summary>
        /// Get the maximumTurnPoints
        /// </summary>
        /// <returns>The int maximumTurnPoints</returns>
        public int GetMaximumTurnPoints()
        {
            return this.maximumTurnPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n\t>currentArmourPoints= " + this.GetCurrentArmourPoints() +
                "\n\t>currentHealthPoints= " + this.GetCurrentHealthPoints() +
                "\n\t>currentMovePoints= " + this.GetCurrentMovePoints() +
                "\n\t>currentOrderPoints= " + this.GetCurrentOrderPoints() +
                "\n\t>currentTurnPoints= " + this.GetCurrentTurnPoints() +
                "\n\t>maximumArmourPoints= " + this.GetMaximumArmourPoints() +
                "\n\t>maximumHealthPoints= " + this.GetMaximumHealthPoints() +
                "\n\t>maximumMovePoints= " + this.GetMaximumMovePoints() +
                "\n\t>maximumOrderPoints= " + this.GetMaximumOrderPoints() +
                "\n\t>maximumTurnPoints= " + this.GetMaximumTurnPoints();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // The current armourPoints for the Talon
            private int currentArmourPoints = int.MinValue;

            // The current healthPoints for the Talon
            private int currentHealthPoints = int.MinValue;

            // The current movePoints for the Talon
            private int currentMovePoints = int.MinValue;

            // The current orderPoints for the Talon
            private int currentOrderPoints = int.MinValue;

            // The current turnPoints for the Talon
            private int currentTurnPoints = int.MinValue;

            // The maximum armourPoints for the Talon
            private int maximumArmourPoints = int.MinValue;

            // The maximum healthPoints for the Talon
            private int maximumHealthPoints = int.MinValue;

            // The maximum movePoints for the Talon
            private int maximumMovePoints = int.MinValue;

            // The maximum orderPoints for the Talon
            private int maximumOrderPoints = int.MinValue;

            // The maximum turnPoints for the Talon
            private int maximumTurnPoints = int.MinValue;

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
                    return new TalonAttributesReport(this.currentArmourPoints, this.currentHealthPoints,
                        this.currentMovePoints, this.currentOrderPoints, this.currentTurnPoints,
                        this.maximumArmourPoints, this.maximumHealthPoints, this.maximumMovePoints,
                        this.maximumOrderPoints, this.maximumTurnPoints);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
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
                return this;
            }

            /// <summary>
            /// Set the value of the Current movePoints
            /// </summary>
            /// <param name="currentMovePoints">The Current movePoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentMovePoints(int currentMovePoints)
            {
                this.currentMovePoints = currentMovePoints;
                return this;
            }

            /// <summary>
            /// Set the value of the Current orderPoints
            /// </summary>
            /// <param name="currentOrderPoints">The Current orderPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentOrderPoints(int currentOrderPoints)
            {
                this.currentOrderPoints = currentOrderPoints;
                return this;
            }

            /// <summary>
            /// Set the value of the Current turnPoints
            /// </summary>
            /// <param name="currentTurnPoints">The Current turnPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentTurnPoints(int currentTurnPoints)
            {
                this.currentTurnPoints = currentTurnPoints;
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
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum movePoints
            /// </summary>
            /// <param name="maximumMovePoints">The Maximum movePoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMaximumMovePoints(int maximumMovePoints)
            {
                this.maximumMovePoints = maximumMovePoints;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum orderPoints
            /// </summary>
            /// <param name="maximumOrderPoints">The Maximum orderPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMaximumOrderPoints(int maximumOrderPoints)
            {
                this.maximumOrderPoints = maximumOrderPoints;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum turnPoints
            /// </summary>
            /// <param name="maximumTurnPoints">The Maximum turnPoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMaximumTurnPoints(int maximumTurnPoints)
            {
                this.maximumTurnPoints = maximumTurnPoints;
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
                if (this.currentArmourPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("currentArmourPoints has not been set");
                }
                // Check that currentHealthPoints has been set
                if (this.currentHealthPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("currentHealthPoints has not been set");
                }
                // Check that currentMovePoints has been set
                if (this.currentMovePoints == int.MinValue)
                {
                    argumentExceptionSet.Add("currentMovePoints has not been set");
                }
                // Check that currentOrderPoints has been set
                if (this.currentOrderPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("currentOrderPoints has not been set");
                }
                // Check that currentTurnPoints has been set
                if (this.currentTurnPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("currentTurnPoints has not been set");
                }
                // Check that maximumArmourPoints has been set
                if (this.maximumArmourPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("maximumArmourPoints has not been set");
                }
                // Check that maximumHealthPoints has been set
                if (this.maximumHealthPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("maximumHealthPoints has not been set");
                }
                // Check that maximumMovePoints has been set
                if (this.maximumMovePoints == int.MinValue)
                {
                    argumentExceptionSet.Add("maximumMovePoints has not been set");
                }
                // Check that maximumOrderPoints has been set
                if (this.maximumOrderPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("maximumOrderPoints has not been set");
                }
                // Check that maximumTurnPoints has been set
                if (this.maximumTurnPoints == int.MinValue)
                {
                    argumentExceptionSet.Add("maximumTurnPoints has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}