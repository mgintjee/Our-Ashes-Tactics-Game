using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TileDetailsImpl
        : ITileDetails
    {
        private readonly TileType tileType;
        private readonly Vector3 vector3;
        private UnitID unitID;

        protected TileDetailsImpl(TileType tileType, Vector3 vector3, UnitID unitID)
        {
            this.tileType = tileType;
            this.vector3 = vector3;
            this.unitID = unitID;
        }

        public void SetUnitID(UnitID unitID)
        {
            this.unitID = unitID;
        }

        public override string ToString()
        {
            return string.Format("Coords:{0}, Type:{1}, UnitID:{2}", this.vector3, this.tileType, this.unitID);
        }

        TileType ITileDetails.GetTileType()
        {
            return tileType;
        }

        UnitID ITileDetails.GetUnitID()
        {
            return unitID;
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

                IInternalBuilder SetUnitID(UnitID unitID);
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
                private UnitID unitID;

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

                IInternalBuilder IInternalBuilder.SetUnitID(UnitID unitID)
                {
                    this.unitID = unitID;
                    return this;
                }

                protected override ITileDetails BuildObj()
                {
                    return new TileDetailsImpl(tileType, vector3, unitID);
                }
            }
        }
    }
}