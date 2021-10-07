using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Offset.Implementations
{
    /// <summary>
    /// Offset Coordinates Implementation
    /// </summary>
    public struct OffsetCoordinates
        : IOffsetCoordinates
    {
        // Todo
        private readonly int _col;

        // Todo
        private readonly OffsetCoordinateType _offsetCoordinateType;

        // Todo
        private readonly int _row;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col">                 </param>
        /// <param name="row">                 </param>
        /// <param name="offsetCoordinateType"></param>
        private OffsetCoordinates(int col, int row, OffsetCoordinateType offsetCoordinateType)
        {
            _col = col;
            _row = row;
            _offsetCoordinateType = offsetCoordinateType;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:{1},({2},{3})",
                this.GetType().Name, _offsetCoordinateType,
                _col, _row);
        }

        /// <inheritdoc/>
        int IOffsetCoordinates.GetCol()
        {
            return _col;
        }

        /// <inheritdoc/>
        OffsetCoordinateType IOffsetCoordinates.GetOffsetCoordinateType()
        {
            return _offsetCoordinateType;
        }

        /// <inheritdoc/>
        int IOffsetCoordinates.GetRow()
        {
            return _row;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IOffsetCoordinates>
            {
                IBuilder SetCol(int col);

                IBuilder SetRow(int row);

                IBuilder SetOffsetCoordinateType(OffsetCoordinateType offsetCoordinateType);
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
            private class InternalBuilder : AbstractBuilder<IOffsetCoordinates>, IBuilder
            {
                // Todo
                private int _row = 0;

                // Todo
                private int _col = 0;

                // Todo
                private OffsetCoordinateType _offsetCoordinateType = OffsetCoordinateType.None;

                /// <inheritdoc/>

                /// <inheritdoc/>
                IBuilder IBuilder.SetCol(int col)
                {
                    _col = col;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetOffsetCoordinateType(OffsetCoordinateType offsetCoordinateType)
                {
                    _offsetCoordinateType = offsetCoordinateType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetRow(int row)
                {
                    _row = row;
                    return this;
                }

                /// <inheritdoc/>
                protected override IOffsetCoordinates BuildObj()
                {
                    // Instantiate a new attributes
                    return new OffsetCoordinates(_row, _col, _offsetCoordinateType);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _row);
                    this.Validate(invalidReasons, _col);
                    this.Validate(invalidReasons, _offsetCoordinateType);
                }
            }
        }
    }
}