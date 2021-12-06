using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Inters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Cube.Impls
{
    /// <summary>
    /// Cube Coordinates Implementation
    /// </summary>
    public struct CubeCoordinates
        : ICubeCoordinates
    {
        // Todo
        private readonly int _x;

        // Todo
        private readonly int _y;

        // Todo
        private readonly int _z;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        private CubeCoordinates(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
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
            hashCode = hashCode * -1521134295 + _x.GetHashCode();
            hashCode = hashCode * -1521134295 + _y.GetHashCode();
            hashCode = hashCode * -1521134295 + _z.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:({1},{2},{3})",
                this.GetType().Name, _x, _y, _z);
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetDistanceFrom(ICubeCoordinates cubeCoordinates)
        {
            return Mathf.Max(Mathf.Abs(_x - cubeCoordinates.GetX()),
                Mathf.Abs(_y - cubeCoordinates.GetY()),
                Mathf.Abs(_z - cubeCoordinates.GetZ()));
        }

        /// <inheritdoc/>
        ICubeCoordinates ICubeCoordinates.GetNegatedCoordinates()
        {
            return new CubeCoordinates(-_x, -_y, -_z);
        }

        /// <inheritdoc/>
        ISet<ICubeCoordinates> ICubeCoordinates.GetNeighbors()
        {
            return new HashSet<ICubeCoordinates>
            {
                new CubeCoordinates( _x + 1, _y, _z - 1),
                new CubeCoordinates( _x + 1, _y - 1, _z),
                new CubeCoordinates( _x, _y + 1, _z - 1),
                new CubeCoordinates( _x, _y - 1, _z + 1),
                new CubeCoordinates( _x - 1, _y, _z + 1),
                new CubeCoordinates( _x - 1, _y + 1, _z)
            };
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetX()
        {
            return _x;
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetY()
        {
            return _y;
        }

        /// <inheritdoc/>
        int ICubeCoordinates.GetZ()
        {
            return _z;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<ICubeCoordinates>
            {
                IBuilder SetX(int x);

                IBuilder SetY(int y);

                IBuilder SetZ(int z);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<ICubeCoordinates>, IBuilder
            {
                // Todo
                private int _x = 0;

                // Todo
                private int _y = 0;

                // Todo
                private int _z = 0;

                /// <inheritdoc/>

                /// <inheritdoc/>
                IBuilder IBuilder.SetX(int x)
                {
                    _x = x;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetY(int y)
                {
                    _y = y;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetZ(int z)
                {
                    _z = z;
                    return this;
                }

                /// <inheritdoc/>
                protected override ICubeCoordinates BuildObj()
                {
                    // Instantiate a new attributes
                    return new CubeCoordinates(_x, _y, _z);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _x);
                    this.Validate(invalidReasons, _y);
                    this.Validate(invalidReasons, _z);
                    if (_x + _y + _z != 0)
                    {
                        invalidReasons.Add("The sum must equal 0. _x=" + _x + ", _y=" + _y + ", _z=" + _z);
                    }
                }
            }
        }
    }
}