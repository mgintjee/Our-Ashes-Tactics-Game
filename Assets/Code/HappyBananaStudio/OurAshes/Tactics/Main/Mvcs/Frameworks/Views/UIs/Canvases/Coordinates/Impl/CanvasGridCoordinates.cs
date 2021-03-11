namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasGridCoordinates
        : ICanvasGridCoordinates
    {
        // Todo
        private readonly int col;

        // Todo
        private readonly int row;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col">
        /// </param>
        /// <param name="row">
        /// </param>
        private CanvasGridCoordinates(int col, int row)
        {
            this.col = col;
            this.row = row;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="obj">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool Equals(object obj)
        {
            // Check if same type
            if (obj != null &&
                obj.GetType() == this.GetType())
            {
                ICanvasGridCoordinates OtherCoord = (ICanvasGridCoordinates)obj;
                bool sameX = this.col == OtherCoord.GetCol();
                bool sameY = this.row == OtherCoord.GetRow();
                return sameX && sameY;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override int GetHashCode()
        {
            // Auto-generated HashCode
            var hashCode = 230791427;
            hashCode = (hashCode * -1521134295) + col.GetHashCode();
            hashCode = (hashCode * -1521134295) + row.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}:(Col={1},Row={2})",
                this.GetType().Name, this.col, this.row);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetCol()
        {
            return this.col;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetRow()
        {
            return this.row;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int col = int.MinValue;

            // Todo
            private int row = int.MinValue;

            /// <summary>
            /// Build the implementation of the object and return it
            /// </summary>
            /// <returns>The new object's interface</returns>
            public ICanvasGridCoordinates Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new CanvasGridCoordinates(this.col, this.row);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="col"></param>
            /// <returns></returns>
            public Builder SetCol(int col)
            {
                this.col = col;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="row"></param>
            /// <returns></returns>
            public Builder SetRow(int row)
            {
                this.row = row;
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
                // Check that col has been set
                if (this.col == int.MinValue)
                {
                    argumentExceptionSet.Add("col has not been set");
                }
                // Check that row has been set
                if (this.row == int.MinValue)
                {
                    argumentExceptionSet.Add("row has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}