/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports
{
    /// <summary>
    /// Report to display the current attributes for a specific Movable
    /// </summary>
    public class MovableAttributesReport
    {
        #region Private Fields

        // The current movePoints for the Movable
        private readonly int currentMovePoints = int.MinValue;

        // The current orderPoints for the Movable
        private readonly int currentOrderPoints = int.MinValue;

        // The current turnPoints for the Movable
        private readonly int currentTurnPoints = int.MinValue;

        // The maximum movePoints for the Movable
        private readonly int maximumMovePoints = int.MinValue;

        // The maximum orderPoints for the Movable
        private readonly int maximumOrderPoints = int.MinValue;

        // The maximum turnPoints for the Movable
        private readonly int maximumTurnPoints = int.MinValue;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="currentMovePoints"> </param>
        /// <param name="currentOrderPoints"></param>
        /// <param name="currentTurnPoints"> </param>
        /// <param name="maximumMovePoints"> </param>
        /// <param name="maximumOrderPoints"></param>
        /// <param name="maximumTurnPoints"> </param>
        private MovableAttributesReport(
            int currentMovePoints, int currentOrderPoints,
            int currentTurnPoints, int maximumMovePoints,
            int maximumOrderPoints, int maximumTurnPoints)
        {
            // Set the current attributes for this report
            this.currentMovePoints = currentMovePoints;
            this.currentOrderPoints = currentOrderPoints;
            this.currentTurnPoints = currentTurnPoints;
            // Set the maximum attributes for this report
            this.maximumMovePoints = maximumMovePoints;
            this.maximumOrderPoints = maximumOrderPoints;
            this.maximumTurnPoints = maximumTurnPoints;
        }

        #endregion Private Constructors

        #region Public Methods

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
            return this.GetType().Name + ":" +
                "\n\t>currentMovePoints= " + this.GetCurrentMovePoints() +
                "\n\t>currentOrderPoints= " + this.GetCurrentOrderPoints() +
                "\n\t>currentTurnPoints= " + this.GetCurrentTurnPoints() +
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

            // The currentMovePoints for the Movable
            private int currentMovePoints = int.MinValue;

            // The currentOrderPoints for the Movable
            private int currentOrderPoints = int.MinValue;

            // The currentTurnPoints for the Movable
            private int currentTurnPoints = int.MinValue;

            // The maximummaximumMovePoints for the Movable
            private int maximumMovePoints = int.MinValue;

            // The maximumOrderPoints for the Movable
            private int maximumOrderPoints = int.MinValue;

            // The maximumTurnPoints for the Movable
            private int maximumTurnPoints = int.MinValue;

            // Tracks whether currentMovePoints has been set
            private bool setCurrentMovePoints = false;

            // Tracks whether currentOrderPoints has been set
            private bool setCurrentOrderPoints = false;

            // Tracks whether currentTurnPoints has been set
            private bool setCurrentTurnPoints = false;

            // Tracks whether maximumMovePoints has been set
            private bool setMaximumMovePoints = false;

            // Tracks whether maximumOrderPoints has been set
            private bool setMaximumOrderPoints = false;

            // Tracks whether maximumTurnPoints has been set
            private bool setMaximumTurnPoints = false;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Build the MovableAttributesReport with the set parameters
            /// </summary>
            /// <returns>The MovableAttributesReport</returns>
            public MovableAttributesReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MovableAttributesReport(
                        this.currentMovePoints, this.currentOrderPoints,
                        this.currentTurnPoints, this.maximumMovePoints,
                        this.maximumOrderPoints, this.maximumTurnPoints);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Current movePoints
            /// </summary>
            /// <param name="currentMovePoints">The Current movePoints to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetCurrentMovePoints(int currentMovePoints)
            {
                this.currentMovePoints = currentMovePoints;
                this.setCurrentMovePoints = true;
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
                this.setCurrentOrderPoints = true;
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
                this.setCurrentTurnPoints = true;
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
                this.setMaximumMovePoints = true;
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
                this.setMaximumOrderPoints = true;
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
                this.setMaximumTurnPoints = true;
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
                // Check that currentMovePoints has been set
                if (!this.setCurrentMovePoints)
                {
                    argumentExceptionSet.Add("currentMovePoints has not been set");
                }
                // Check that currentOrderPoints has been set
                if (!this.setCurrentOrderPoints)
                {
                    argumentExceptionSet.Add("currentOrderPoints has not been set");
                }
                // Check that currentTurnPoints has been set
                if (!this.setCurrentTurnPoints)
                {
                    argumentExceptionSet.Add("currentTurnPoints has not been set");
                }
                // Check that maximumMovePoints has been set
                if (!this.setMaximumMovePoints)
                {
                    argumentExceptionSet.Add("maximumMovePoints has not been set");
                }
                // Check that maximumOrderPoints has been set
                if (!this.setMaximumOrderPoints)
                {
                    argumentExceptionSet.Add("maximumOrderPoints has not been set");
                }
                // Check that maximumTurnPoints has been set
                if (!this.setMaximumTurnPoints)
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