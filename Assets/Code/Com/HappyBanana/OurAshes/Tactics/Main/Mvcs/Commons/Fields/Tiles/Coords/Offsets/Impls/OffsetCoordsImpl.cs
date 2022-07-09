using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Types;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Coords.Offsets.Impls
{
    /// <summary>
    /// Offset Coordinates Impl
    /// </summary>
    public struct OffsetCoordsImpl
        : IOffsetCoords
    {
        // Todo
        private readonly OffsetCoordsType offsetCoordinateType;

        // Todo
        private readonly Vector2 vector2;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="col">                 </param>
        /// <param name="row">                 </param>
        /// <param name="offsetCoordinateType"></param>
        private OffsetCoordsImpl(Vector2 vector2, OffsetCoordsType offsetCoordinateType)
        {
            this.vector2 = vector2;
            this.offsetCoordinateType = offsetCoordinateType;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2})",
                this.GetType().Name, StringUtils.Format(this.offsetCoordinateType),
                this.vector2);
        }

        /// <inheritdoc/>
        OffsetCoordsType IOffsetCoords.GetOffsetCoordsType()
        {
            return offsetCoordinateType;
        }

        /// <inheritdoc/>
        Vector2 IOffsetCoords.GetVector2()
        {
            return this.vector2;
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder
                : IBuilder<IOffsetCoords>
            {
                IBuilder SetVector2(Vector2 vector);

                IBuilder SetOffsetCoordsType(OffsetCoordsType offsetCoordinateType);
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
            /// Builder Impl for this object
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<IOffsetCoords>, IBuilder
            {
                // Todo
                private Vector2 vector2;

                // Todo
                private OffsetCoordsType offsetCoordsType = OffsetCoordsType.None;

                /// <inheritdoc/>
                IBuilder IBuilder.SetOffsetCoordsType(OffsetCoordsType offsetCoordsType)
                {
                    this.offsetCoordsType = offsetCoordsType;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetVector2(Vector2 vector2)
                {
                    this.vector2 = vector2;
                    return this;
                }

                /// <inheritdoc/>
                protected override IOffsetCoords BuildObj()
                {
                    // Instantiate a new attributes
                    return new OffsetCoordsImpl(this.vector2, this.offsetCoordsType);
                }

                /// <inheritdoc/>
                protected override void Validate(IList<string> invalidReasons)
                {
                    this.Validate(invalidReasons, vector2);
                    this.Validate(invalidReasons, offsetCoordsType);
                }
            }
        }
    }
}