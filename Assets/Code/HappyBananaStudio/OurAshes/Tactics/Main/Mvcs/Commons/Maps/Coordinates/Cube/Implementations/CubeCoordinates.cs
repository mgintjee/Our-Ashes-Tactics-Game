using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Maps.Coordinates.Cube.Implementations
{
    /// <summary>
    /// Cube Coordinates Implementation
    /// </summary>
    public struct CubeCoordinates
        : ICubeCoordinates
    {
        // Todo
        private readonly int _xValue;

        // Todo
        private readonly int _yValue;

        // Todo
        private readonly int _zValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
        /// <param name="zValue"></param>
        public CubeCoordinates(int xValue, int yValue, int zValue)
        {
            int sum = xValue + yValue + zValue;
            if (sum != 0)
            {
                throw ExceptionUtil.Arguments.Build(
                    "Unable to construct {}. Invalid Parameters. Sum must equal 0." +
                    "\n\t> x={}, y={}, z={}, sum={}",
                    typeof(ICubeCoordinates), xValue, yValue, zValue, sum);
            }
            _xValue = xValue;
            _yValue = yValue;
            _zValue = zValue;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -172019209;
            hashCode = hashCode * -1521134295 + _xValue.GetHashCode();
            hashCode = hashCode * -1521134295 + _yValue.GetHashCode();
            hashCode = hashCode * -1521134295 + _zValue.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2},{3})",
                this.GetType().Name, _xValue, _yValue, _zValue);
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetDistanceFrom(ICubeCoordinates cubeCoordinates)
        {
            return Mathf.Max(Mathf.Abs(_xValue - cubeCoordinates.GetX()),
                Mathf.Abs(_yValue - cubeCoordinates.GetY()),
                Mathf.Abs(_zValue - cubeCoordinates.GetZ()));
        }

        /// <inheritdoc/>
        ICubeCoordinates ICubeCoordinates.GetNegatedCoordinates()
        {
            return new CubeCoordinates(-_xValue, -_yValue, -_zValue);
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> ICubeCoordinates.GetNeighbors()
        {
            return new HashSet<ICubeCoordinates>
            {
                new CubeCoordinates( _xValue + 1, _yValue, _zValue - 1),
                new CubeCoordinates( _xValue + 1, _yValue - 1, _zValue),
                new CubeCoordinates( _xValue, _yValue + 1, _zValue - 1),
                new CubeCoordinates( _xValue, _yValue - 1, _zValue + 1),
                new CubeCoordinates( _xValue - 1, _yValue, _zValue + 1),
                new CubeCoordinates( _xValue - 1, _yValue + 1, _zValue)
            };
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetX()
        {
            return _xValue;
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetY()
        {
            return _yValue;
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetZ()
        {
            return _zValue;
        }
    }
}