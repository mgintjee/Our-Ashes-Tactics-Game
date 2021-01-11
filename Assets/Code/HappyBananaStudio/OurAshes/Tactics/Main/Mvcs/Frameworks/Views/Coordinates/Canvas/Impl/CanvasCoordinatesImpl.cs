namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Coordinates.Canvas.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.Coordinates.Canvas.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasGridCoordinatesImpl
        : ICanvasGridCoordinates
    {
        // Todo
        private readonly int xValue;

        // Todo
        private readonly int yValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private CanvasGridCoordinatesImpl(int x, int y)
        {
            xValue = x;
            yValue = y;
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
                bool sameX = this.xValue == OtherCoord.GetX();
                bool sameY = this.yValue == OtherCoord.GetY();
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
            hashCode = (hashCode * -1521134295) + xValue.GetHashCode();
            hashCode = (hashCode * -1521134295) + yValue.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2})", this.GetType().Name, this.xValue, this.yValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetX()
        {
            return this.xValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICanvasGridCoordinates.GetY()
        {
            return this.yValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int xValue = int.MinValue;

            // Todo
            private int yValue = int.MinValue;

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
                    return new CanvasGridCoordinatesImpl(this.xValue, this.yValue);
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
            /// <param name="xValue"></param>
            /// <returns></returns>
            public Builder SetX(int xValue)
            {
                this.xValue = xValue;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="yValue"></param>
            /// <returns></returns>
            public Builder SetY(int yValue)
            {
                this.yValue = yValue;
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
                // Check that xValue has been set
                if (this.xValue == int.MinValue)
                {
                    argumentExceptionSet.Add("X-Value has not been set");
                }
                // Check that yValue has been set
                if (this.yValue == int.MinValue)
                {
                    argumentExceptionSet.Add("Y-Value has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}