using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Impl
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
            if (x + y + z != 0)
            {
                throw ExceptionUtil.Arguments.Build(
                    "Unable to construct ?. Invalid Parameters. Sum must equal 0." +
                    "\n\t> x=? + y=? + z=? != ?",
                    typeof(ICubeCoordinates), x, y, z, x + y + z);
            }
            xValue = x;
            yValue = y;
            zValue = z;
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
    }
}