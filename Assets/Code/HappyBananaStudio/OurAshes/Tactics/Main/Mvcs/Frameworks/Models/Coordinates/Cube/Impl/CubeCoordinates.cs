namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;

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
        private CubeCoordinates(int x, int y, int z)
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
                throw ExceptionUtil.Arguments.Build(
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
                bool sameX = this.xValue == OtherCoord.GetX();
                bool sameY = this.yValue == OtherCoord.GetY();
                bool sameZ = this.zValue == OtherCoord.GetZ();
                return sameX && sameY && sameZ;
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
            return string.Format("{0}:({1},{2},{3})", this.GetType().Name, this.xValue, this.yValue, this.zValue);
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private int xValue = 0;

            // Todo
            private int yValue = 0;

            // Todo
            private int zValue = 0;

            /// <summary>
            /// Build the implementation of the object and return it
            /// </summary>
            /// <returns>The new object's interface</returns>
            public ICubeCoordinates Build()
            {
                // Instantiate a new Object
                return new CubeCoordinates(this.xValue, this.yValue, this.zValue);
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
            /// <param name="zValue"></param>
            /// <returns></returns>
            public Builder SetZ(int zValue)
            {
                this.zValue = zValue;
                return this;
            }
        }
    }
}