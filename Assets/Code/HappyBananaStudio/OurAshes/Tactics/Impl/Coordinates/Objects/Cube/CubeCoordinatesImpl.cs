

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Cube
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;

    /// <summary>
    /// Todo
    /// </summary>
    public struct CubeCoordinatesImpl
        : ICubeCoordinates
    {
        // Todo
        private readonly int xValue;

        // Todo
        private readonly int yValue;

        // Todo
        private readonly int zValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        public CubeCoordinatesImpl(int x, int y, int z)
        {
            // Todo
            if (x + y + z == 0)
            {
                xValue = x;
                yValue = y;
                zValue = z;
            }
            else
            {
                throw ArgumentExceptionUtil.Build(
                    "Unable to construct ?. Invalid Parameters. Sum must equal 0.\n\t> x=? + y=? + z=? == ?",
                    typeof(ICubeCoordinates), x, y, z, x + y + z);
            }
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
                ICubeCoordinates OtherCoord = (ICubeCoordinates)obj;
                bool SameX = this.xValue == OtherCoord.GetX();
                bool SameY = this.yValue == OtherCoord.GetY();
                bool SameZ = this.zValue == OtherCoord.GetZ();
                return SameX && SameY && SameZ;
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
            hashCode = (hashCode * -1521134295) + zValue.GetHashCode();
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
                "({0},{1},{2})", this.xValue, this.yValue, this.zValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICubeCoordinates.GetX()
        {
            return this.xValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICubeCoordinates.GetY()
        {
            return this.yValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int ICubeCoordinates.GetZ()
        {
            return this.zValue;
        }
    }
}
