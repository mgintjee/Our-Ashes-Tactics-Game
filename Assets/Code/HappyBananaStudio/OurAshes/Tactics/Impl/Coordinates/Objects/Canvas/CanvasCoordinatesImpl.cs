namespace HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Canvas
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Canvas;

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
        public CanvasGridCoordinatesImpl(int x, int y)
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
                bool SameX = this.xValue == OtherCoord.GetX();
                bool SameY = this.yValue == OtherCoord.GetY();
                return SameX && SameY;
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
            return string.Format(
                "CanvasGrid({0},{1})", this.xValue, this.yValue);
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
    }
}