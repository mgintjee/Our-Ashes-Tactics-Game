/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MovableAttributesReportImpl
        : IMovableAttributesReport
    {
        // Todo
        private readonly int currentActionPoints;

        // Todo
        private readonly int currentMovePoints;

        // Todo
        private readonly int maximumActionPoints;

        // Todo
        private readonly int maximumMovePoints;

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="currentMovePoints">
        /// </param>
        /// <param name="currentActionPoints">
        /// </param>
        /// <param name="maximumMovePoints">
        /// </param>
        /// <param name="maximumActionPoints">
        /// </param>
        private MovableAttributesReportImpl(int currentMovePoints, int currentActionPoints,
            int maximumMovePoints, int maximumActionPoints)
        {
            // Set the current attributes for this report
            this.currentMovePoints = currentMovePoints;
            this.currentActionPoints = currentActionPoints;
            // Set the maximum attributes for this report
            this.maximumMovePoints = maximumMovePoints;
            this.maximumActionPoints = maximumActionPoints;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>Current MovePoints=" + this.currentMovePoints +
                "\n\t>Current ActionPoints=" + this.currentActionPoints +
                "\n\t>Maximum MovePoints=" + this.maximumMovePoints +
                "\n\t>Maximum ActionPoints=" + this.maximumActionPoints;
        }

        /// <summary>
        /// Get the current MovePoints
        /// </summary>
        /// <returns>
        /// The int current MovePoints
        /// </returns>
        int IMovableAttributesReport.GetCurrentMovePoints()
        {
            return this.currentMovePoints;
        }

        /// <summary>
        /// Get the current TurnPoints
        /// </summary>
        /// <returns>
        /// The int current TurnPoints
        /// </returns>
        int IMovableAttributesReport.GetCurrentActionPoints()
        {
            return this.currentActionPoints;
        }

        /// <summary>
        /// Get the maximum MovePoints
        /// </summary>
        /// <returns>
        /// The int maximum MovePoints
        /// </returns>
        int IMovableAttributesReport.GetMaximumMovePoints()
        {
            return this.maximumMovePoints;
        }

        /// <summary>
        /// Get the maximum TurnPoints
        /// </summary>
        /// <returns>
        /// The int maximum TurnPoints
        /// </returns>
        int IMovableAttributesReport.GetMaximumActionPoints()
        {
            return this.maximumActionPoints;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // The currentActionPoints for the Movable
            private int currentActionPoints = int.MinValue;

            // The currentMovePoints for the Movable
            private int currentMovePoints = int.MinValue;

            // The maximumActionPoints for the Movable
            private int maximumActionPoints = int.MinValue;

            // The maximumMovePoints for the Movable
            private int maximumMovePoints = int.MinValue;

            // Tracks whether currentActionPoints has been set
            private bool setCurrentActionPoints = false;

            // Tracks whether currentMovePoints has been set
            private bool setCurrentMovePoints = false;

            // Tracks whether maximumActionPoints has been set
            private bool setMaximumActionPoints = false;

            // Tracks whether maximumMovePoints has been set
            private bool setMaximumMovePoints = false;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IMovableAttributesReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new MovableAttributesReportImpl(this.currentMovePoints, this.currentActionPoints,
                        this.maximumMovePoints, this.maximumActionPoints);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Current turnPoints
            /// </summary>
            /// <param name="currentActionPoints">
            /// The Current turnPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetCurrentActionPoints(int currentActionPoints)
            {
                this.currentActionPoints = currentActionPoints;
                this.setCurrentActionPoints = true;
                return this;
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
            /// Set the value of the Maximum turnPoints
            /// </summary>
            /// <param name="maximumActionPoints">
            /// The Maximum turnPoints to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetMaximumActionPoints(int maximumActionPoints)
            {
                this.maximumActionPoints = maximumActionPoints;
                this.setMaximumActionPoints = true;
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
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that currentMovePoints has been set
                if (!this.setCurrentMovePoints)
                {
                    argumentExceptionSet.Add("current MovePoints has not been set");
                }
                // Check that currentTurnPoints has been set
                if (!this.setCurrentActionPoints)
                {
                    argumentExceptionSet.Add("current ActionPoints has not been set");
                }
                // Check that maximumMovePoints has been set
                if (!this.setMaximumMovePoints)
                {
                    argumentExceptionSet.Add("maximum MovePoints has not been set");
                }
                // Check that maximumTurnPoints has been set
                if (!this.setMaximumActionPoints)
                {
                    argumentExceptionSet.Add("maximum ActionPoints has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}
