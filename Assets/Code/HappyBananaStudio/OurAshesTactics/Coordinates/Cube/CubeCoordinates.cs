/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Coordinates.Cube
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct CubeCoordinates
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
        public CubeCoordinates(int x, int y, int z)
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
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. Sum must equal 0." +
                    "\n\t> x=? + y=? + z=? == ?", typeof(ICubeCoordinates), x, y, z, (x + y + z));
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
                bool SameX = this.GetX() == OtherCoord.GetX();
                bool SameY = this.GetY() == OtherCoord.GetY();
                bool SameZ = this.GetZ() == OtherCoord.GetZ();
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
            hashCode = hashCode * -1521134295 + xValue.GetHashCode();
            hashCode = hashCode * -1521134295 + yValue.GetHashCode();
            hashCode = hashCode * -1521134295 + zValue.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ICubeCoordinates GetNegatedCubeCoordinates()
        {
            return new CubeCoordinates(-this.xValue, -this.yValue, -this.zValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetX()
        {
            return this.xValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetY()
        {
            return this.yValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetZ()
        {
            return this.zValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0},{1},{2})",
                this.GetX(), this.GetY(), this.GetZ());
        }
    }
}