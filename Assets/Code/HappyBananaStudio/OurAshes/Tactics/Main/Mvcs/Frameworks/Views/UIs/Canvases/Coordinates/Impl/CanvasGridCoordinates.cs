namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasGridCoordinates
        : ICanvasGridCoordinates
    {
        // Todo
        private readonly int colIndex;

        // Todo
        private readonly int rowIndex;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colIndex">
        /// </param>
        /// <param name="rowIndex">
        /// </param>
        private CanvasGridCoordinates(int colIndex, int rowIndex)
        {
            this.colIndex = colIndex;
            this.rowIndex = rowIndex;
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
                bool sameX = this.colIndex == OtherCoord.GetColIndex();
                bool sameY = this.rowIndex == OtherCoord.GetRowIndex();
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
            hashCode = (hashCode * -1521134295) + colIndex.GetHashCode();
            hashCode = (hashCode * -1521134295) + rowIndex.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})", this.GetType().Name, this.colIndex, this.rowIndex);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetColIndex()
        {
            return this.colIndex;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetRowIndex()
        {
            return this.rowIndex;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int colIndex = int.MinValue;

            // Todo
            private int rowIndex = int.MinValue;

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
                    return new CanvasGridCoordinates(this.colIndex, this.rowIndex);
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
            /// <param name="colIndex"></param>
            /// <returns></returns>
            public Builder SetColIndex(int colIndex)
            {
                this.colIndex = colIndex;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="rowIndex"></param>
            /// <returns></returns>
            public Builder SetRowIndex(int rowIndex)
            {
                this.rowIndex = rowIndex;
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
                // Check that colIndex has been set
                if (this.colIndex == int.MinValue)
                {
                    argumentExceptionSet.Add("colIndex has not been set");
                }
                // Check that rowIndex has been set
                if (this.rowIndex == int.MinValue)
                {
                    argumentExceptionSet.Add("rowIndex has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}