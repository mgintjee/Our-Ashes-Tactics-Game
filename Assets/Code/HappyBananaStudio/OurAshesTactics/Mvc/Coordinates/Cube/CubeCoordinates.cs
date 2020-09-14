/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Coordinates.Cube
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CubeCoordinates
    {
        #region Private Fields

        // Todo
        private readonly int xValue;

        // Todo
        private readonly int yValue;

        // Todo
        private readonly int zValue;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
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
                throw new ArgumentException("Invalid parameters for " + this.GetType() + ". Parameters must sum to 0." +
                    "\n\t>x=" + x +
                    "\n\t>y=" + y +
                    "\n\t>z=" + z);
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Check if same type
            if (obj != null &&
                obj.GetType() == this.GetType())
            {
                CubeCoordinates OtherCoord = (CubeCoordinates)obj;
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
        /// <returns></returns>
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
        /// <returns></returns>
        public CubeCoordinates GetNegatedCubeCoordinates()
        {
            return new CubeCoordinates(-this.xValue, -this.yValue, -this.zValue);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
            return this.xValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetY()
        {
            return this.yValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetZ()
        {
            return this.zValue;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1},{2})",
                this.GetX(), this.GetY(), this.GetZ());
        }

        #endregion Public Methods
    }
}