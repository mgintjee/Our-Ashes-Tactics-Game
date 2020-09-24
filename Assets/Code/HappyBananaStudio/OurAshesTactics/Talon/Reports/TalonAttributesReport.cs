/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Attributes.Reports
{
    /// <summary>
    /// Report to display the current attibutes for a specific Talon
    /// </summary>
    public class TalonAttributesReport
    {
        #region Private Fields

        // Todo
        private readonly DestructibleAttributesReport destructableAttributesReport;

        // Todo
        private readonly FireableAttributesReport fireableAttributesReport;

        // Todo
        private readonly MovableAttributesReport moveableAttributesReport;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="destructableAttributesReport"></param>
        /// <param name="fireableAttributesReport">    </param>
        /// <param name="moveableAttributesReport">    </param>
        private TalonAttributesReport(
            DestructibleAttributesReport destructableAttributesReport,
            FireableAttributesReport fireableAttributesReport,
            MovableAttributesReport moveableAttributesReport)
        {
            this.destructableAttributesReport = destructableAttributesReport;
            this.fireableAttributesReport = fireableAttributesReport;
            this.moveableAttributesReport = moveableAttributesReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Get the destructableAttributesReport
        /// </summary>
        /// <returns>The DestructableAttributesReport</returns>
        public DestructibleAttributesReport GetDestructableAttributesReport()
        {
            return this.destructableAttributesReport;
        }

        /// <summary>
        /// Get the fireableAttributesReport
        /// </summary>
        /// <returns>The FireableAttributesReport</returns>
        public FireableAttributesReport GetFireableAttributesReport()
        {
            return this.fireableAttributesReport;
        }

        /// <summary>
        /// Get the moveableAttributesReport
        /// </summary>
        /// <returns>The MoveableAttributesReport</returns>
        public MovableAttributesReport GetMovableAttributesReport()
        {
            return this.moveableAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetDestructableAttributesReport() +
                "\n\t>" + this.GetFireableAttributesReport() +
                "\n\t>" + this.GetMovableAttributesReport();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Todo
            private DestructibleAttributesReport destructableAttributesReport = null;

            // Todo
            private FireableAttributesReport fireableAttributesReport = null;

            // Todo
            private MovableAttributesReport moveableAttributesReport = null;

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
                    return new TalonAttributesReport(this.destructableAttributesReport,
                        this.fireableAttributesReport,
                        this.moveableAttributesReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType().Name + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the DestructableAttributesReport
            /// </summary>
            /// <param name="destructableAttributesReport">
            /// The DestructableAttributesReport to set
            /// </param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetDestructableAttributesReport(DestructibleAttributesReport destructableAttributesReport)
            {
                this.destructableAttributesReport = destructableAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the FireableAttributesReport
            /// </summary>
            /// <param name="fireableAttributesReport">The FireableAttributesReport to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetFireableAttributesReport(FireableAttributesReport fireableAttributesReport)
            {
                this.fireableAttributesReport = fireableAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the MoveableAttributesReport
            /// </summary>
            /// <param name="moveableAttributesReport">The MoveableAttributesReport to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetMoveableAttributesReport(MovableAttributesReport moveableAttributesReport)
            {
                this.moveableAttributesReport = moveableAttributesReport;
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
                // Check that destructableAttributesReport has been set
                if (this.destructableAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(DestructibleAttributesReport).Name + "has not been set");
                }
                // Check that fireableAttributesReport has been set
                if (this.fireableAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(FireableAttributesReport).Name + "has not been set");
                }
                // Check that moveableAttributesReport has been set
                if (this.moveableAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(MovableAttributesReport).Name + "has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}