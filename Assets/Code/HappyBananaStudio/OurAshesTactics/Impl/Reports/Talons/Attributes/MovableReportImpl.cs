/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct MovableReportImpl
        : IMovableReport
    {
        // Todo
        private readonly int currentMovePoints;

        // Todo
        private readonly int currentOrderPoints;

        // Todo
        private readonly int currentTurnPoints;

        // Todo
        private readonly int maximumMovePoints;

        // Todo
        private readonly int maximumOrderPoints;

        // Todo
        private readonly int maximumTurnPoints;

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="currentMovePoints">
        /// </param>
        /// <param name="currentOrderPoints">
        /// </param>
        /// <param name="currentTurnPoints">
        /// </param>
        /// <param name="maximumMovePoints">
        /// </param>
        /// <param name="maximumOrderPoints">
        /// </param>
        /// <param name="maximumTurnPoints">
        /// </param>
        private MovableReportImpl(int currentMovePoints, int currentOrderPoints,
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

        /// <summary>
        /// Get the current MovePoints
        /// </summary>
        /// <returns>
        /// The int current MovePoints
        /// </returns>
        public int GetCurrentMovePoints()
        {
            return this.currentMovePoints;
        }

        /// <summary>
        /// Get the current OrderPoints
        /// </summary>
        /// <returns>
        /// The int current OrderPoints
        /// </returns>
        public int GetCurrentOrderPoints()
        {
            return this.currentOrderPoints;
        }

        /// <summary>
        /// Get the current TurnPoints
        /// </summary>
        /// <returns>
        /// The int current TurnPoints
        /// </returns>
        public int GetCurrentTurnPoints()
        {
            return this.currentTurnPoints;
        }

        /// <summary>
        /// Get the maximum MovePoints
        /// </summary>
        /// <returns>
        /// The int maximum MovePoints
        /// </returns>
        public int GetMaximumMovePoints()
        {
            return this.maximumMovePoints;
        }

        /// <summary>
        /// Get the maximum OrderPoints
        /// </summary>
        /// <returns>
        /// The int maximum OrderPoints
        /// </returns>
        public int GetMaximumOrderPoints()
        {
            return this.maximumOrderPoints;
        }

        /// <summary>
        /// Get the maximum TurnPoints
        /// </summary>
        /// <returns>
        /// The int maximum TurnPoints
        /// </returns>
        public int GetMaximumTurnPoints()
        {
            return this.maximumTurnPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Current MovePoints=" + this.GetCurrentMovePoints() +
                "\n\t>Current OrderPoints=" + this.GetCurrentOrderPoints() +
                "\n\t>Maximum TurnPoints=" + this.GetCurrentTurnPoints() +
                "\n\t>Maximum MovePoints=" + this.GetMaximumMovePoints() +
                "\n\t>Maximum OrderPoints=" + this.GetMaximumOrderPoints() +
                "\n\t>Maximum TurnPoints=" + this.GetMaximumTurnPoints();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
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

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IMovableReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MovableReportImpl(
                        this.currentMovePoints, this.currentOrderPoints,
                        this.currentTurnPoints, this.maximumMovePoints,
                        this.maximumOrderPoints, this.maximumTurnPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Current movePoints
            /// </summary>
            /// <param name="currentMovePoints">
            /// The Current movePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentMovePoints(int currentMovePoints)
            {
                this.currentMovePoints = currentMovePoints;
                this.setCurrentMovePoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Current orderPoints
            /// </summary>
            /// <param name="currentOrderPoints">
            /// The Current orderPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentOrderPoints(int currentOrderPoints)
            {
                this.currentOrderPoints = currentOrderPoints;
                this.setCurrentOrderPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Current turnPoints
            /// </summary>
            /// <param name="currentTurnPoints">
            /// The Current turnPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentTurnPoints(int currentTurnPoints)
            {
                this.currentTurnPoints = currentTurnPoints;
                this.setCurrentTurnPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum movePoints
            /// </summary>
            /// <param name="maximumMovePoints">
            /// The Maximum movePoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumMovePoints(int maximumMovePoints)
            {
                this.maximumMovePoints = maximumMovePoints;
                this.setMaximumMovePoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum orderPoints
            /// </summary>
            /// <param name="maximumOrderPoints">
            /// The Maximum orderPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumOrderPoints(int maximumOrderPoints)
            {
                this.maximumOrderPoints = maximumOrderPoints;
                this.setMaximumOrderPoints = true;
                return this;
            }

            /// <summary>
            /// Set the value of the Maximum turnPoints
            /// </summary>
            /// <param name="maximumTurnPoints">
            /// The Maximum turnPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumTurnPoints(int maximumTurnPoints)
            {
                this.maximumTurnPoints = maximumTurnPoints;
                this.setMaximumTurnPoints = true;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that currentMovePoints has been set
                if (!this.setCurrentMovePoints)
                {
                    argumentExceptionSet.Add("current MovePoints has not been set");
                }
                // Check that currentOrderPoints has been set
                if (!this.setCurrentOrderPoints)
                {
                    argumentExceptionSet.Add("current OrderPoints has not been set");
                }
                // Check that currentTurnPoints has been set
                if (!this.setCurrentTurnPoints)
                {
                    argumentExceptionSet.Add("current TurnPoints has not been set");
                }
                // Check that maximumMovePoints has been set
                if (!this.setMaximumMovePoints)
                {
                    argumentExceptionSet.Add("maximum MovePoints has not been set");
                }
                // Check that maximumOrderPoints has been set
                if (!this.setMaximumOrderPoints)
                {
                    argumentExceptionSet.Add("maximum OrderPoints has not been set");
                }
                // Check that maximumTurnPoints has been set
                if (!this.setMaximumTurnPoints)
                {
                    argumentExceptionSet.Add("maximum TurnPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}