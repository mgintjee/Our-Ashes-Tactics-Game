using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldDetailsImpl
        : IFieldDetails
    {
        // Todo: Include the seed for the map
        private readonly FieldID fieldID;

        private readonly FieldBiome fieldBiome;
        private readonly FieldShape fieldShape;
        private readonly FieldSize fieldSize;
        private readonly IList<ITileDetails> tileDetails;

        protected FieldDetailsImpl(FieldID fieldID, FieldBiome fieldBiome, FieldShape fieldShape, FieldSize fieldSize, IList<ITileDetails> tileDetails)
        {
            this.fieldID = fieldID;
            this.fieldBiome = fieldBiome;
            this.fieldShape = fieldShape;
            this.fieldSize = fieldSize;
            this.tileDetails = tileDetails;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: ID:{1}, Biome:{2}, Size:{3}, Shape:{4}, Tiles: {5}",
                this.GetType().Name, this.fieldID, this.fieldBiome, this.fieldSize, this.fieldShape, this.tileDetails.Count);
        }

        FieldBiome IFieldDetails.GetFieldBiome()
        {
            return this.fieldBiome;
        }

        FieldID IFieldDetails.GetFieldID()
        {
            return this.fieldID;
        }

        FieldShape IFieldDetails.GetFieldShape()
        {
            return this.fieldShape;
        }

        FieldSize IFieldDetails.GetFieldSize()
        {
            return this.fieldSize;
        }

        IList<ITileDetails> IFieldDetails.GetTileDetails()
        {
            return new List<ITileDetails>(this.tileDetails);
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
                : IBuilder<IFieldDetails>
            {
                IInternalBuilder SetFieldID(FieldID fieldID);

                IInternalBuilder SetFieldSize(FieldSize fieldSize);

                IInternalBuilder SetFieldBiome(FieldBiome fieldBiome);

                IInternalBuilder SetFieldShape(FieldShape fieldShape);

                IInternalBuilder SetTileDetails(IList<ITileDetails> tileDetails);
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
                : AbstractBuilder<IFieldDetails>, IInternalBuilder
            {
                private FieldID fieldID;
                private FieldBiome fieldBiome;
                private FieldShape fieldShape;
                private FieldSize fieldSize;
                private IList<ITileDetails> tileDetails;

                IInternalBuilder IInternalBuilder.SetFieldBiome(FieldBiome fieldBiome)
                {
                    this.fieldBiome = fieldBiome;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFieldID(FieldID fieldID)
                {
                    this.fieldID = fieldID;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFieldShape(FieldShape fieldShape)
                {
                    this.fieldShape = fieldShape;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetFieldSize(FieldSize fieldSize)
                {
                    this.fieldSize = fieldSize;
                    return this;
                }

                IInternalBuilder IInternalBuilder.SetTileDetails(IList<ITileDetails> tileDetails)
                {
                    this.tileDetails = new List<ITileDetails>(tileDetails);
                    return this;
                }

                protected override IFieldDetails BuildObj()
                {
                    return new FieldDetailsImpl(fieldID, fieldBiome, fieldShape, fieldSize, tileDetails);
                }
            }
        }
    }
}