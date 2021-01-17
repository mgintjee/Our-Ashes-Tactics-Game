namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Offset.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Offset.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Offset.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct OffsetCoordinates
        : IOffsetCoordinates
    {
        // Todo
        private readonly int colCoordinate;

        // Todo
        private readonly OffsetCoordinateType offsetCoordinateType;

        // Todo
        private readonly int rowCoordinate;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colCoordinate">
        /// </param>
        /// <param name="rowCoordinate">
        /// </param>
        /// <param name="offsetCoordinateType">
        /// </param>
        private OffsetCoordinates(int colCoordinate, int rowCoordinate, OffsetCoordinateType offsetCoordinateType)
        {
            this.colCoordinate = colCoordinate;
            this.rowCoordinate = rowCoordinate;
            this.offsetCoordinateType = offsetCoordinateType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetCol()
        {
            return this.colCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public OffsetCoordinateType GetOffsetCoordinateType()
        {
            return this.offsetCoordinateType;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetRow()
        {
            return this.rowCoordinate;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int colCoordinate = int.MinValue;

            // Todo
            private OffsetCoordinateType offsetCoordinateType = OffsetCoordinateType.None;

            // Todo
            private int rowCoordinate = int.MinValue;

            /// <summary>
            /// Build the implementation of the object and return it
            /// </summary>
            /// <returns>The new object's interface</returns>
            public IOffsetCoordinates Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new OffsetCoordinates(this.colCoordinate, this.rowCoordinate, this.offsetCoordinateType);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colCoordinate"></param>
            /// <returns></returns>
            public Builder SetCol(int colCoordinate)
            {
                this.colCoordinate = colCoordinate;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rowCoordinate"></param>
            /// <returns></returns>
            public Builder SetRow(int rowCoordinate)
            {
                this.rowCoordinate = rowCoordinate;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="offsetCoordinateType"></param>
            /// <returns></returns>
            public Builder SetOffsetCoordinateType(OffsetCoordinateType offsetCoordinateType)
            {
                this.offsetCoordinateType = offsetCoordinateType;
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
                // Check that colCoordinate has been set
                if (this.colCoordinate == int.MinValue)
                {
                    argumentExceptionSet.Add("Col coordinate has not been set");
                }
                // Check that rowCoordinate has been set
                if (this.rowCoordinate == int.MinValue)
                {
                    argumentExceptionSet.Add("Row coordinate has not been set");
                }
                // Check that offsetCoordinateType has been set
                if (this.offsetCoordinateType == OffsetCoordinateType.None)
                {
                    argumentExceptionSet.Add(typeof(OffsetCoordinateType).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}