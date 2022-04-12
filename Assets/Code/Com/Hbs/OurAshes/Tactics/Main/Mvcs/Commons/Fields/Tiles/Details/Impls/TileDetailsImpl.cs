using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileDetailsImpl
        : ITileDetails
    {
        private readonly TileType tileType;
        private readonly Vector3 vector3;

        protected TileDetailsImpl(TileType tileType, Vector3 vector3)
        {
            this.tileType = tileType;
            this.vector3 = vector3;
        }

        TileType ITileDetails.GetTileType()
        {
            return tileType;
        }

        Vector3 ITileDetails.GetVector3()
        {
            return new Vector3(vector3.X, vector3.Y, vector3.Z);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IBuilder<ITileDetails>
            {
                IInternalBuilder SetTileType(TileType tileType);

                IInternalBuilder SetVector3(Vector3 vector3);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder
                : AbstractBuilder<ITileDetails>, IInternalBuilder
            {
                private TileType tileType;
                private Vector3 vector3;

                IInternalBuilder IInternalBuilder.SetTileType(TileType tileType)
                {
                    this.tileType = tileType;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetVector3(Vector3 vector3)
                {
                    this.vector3 = vector3;
                    return this;
                }

                protected override ITileDetails BuildObj()
                {
                    return new TileDetailsImpl(tileType, vector3);
                }
            }
        }
    }
}