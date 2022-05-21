using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls
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
        private readonly ISet<ITileDetails> tileDetails;

        protected FieldDetailsImpl(FieldID fieldID, FieldBiome fieldBiome, FieldShape fieldShape, FieldSize fieldSize, ISet<ITileDetails> tileDetails)
        {
            this.fieldID = fieldID;
            this.fieldBiome = fieldBiome;
            this.fieldShape = fieldShape;
            this.fieldSize = fieldSize;
            this.tileDetails = tileDetails;
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

        ISet<ITileDetails> IFieldDetails.GetTileDetails()
        {
            return new HashSet<ITileDetails>(this.tileDetails);
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

                IInternalBuilder SetTileDetails(ISet<ITileDetails> tileDetails);
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
                private ISet<ITileDetails> tileDetails;

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

                IInternalBuilder IInternalBuilder.SetTileDetails(ISet<ITileDetails> tileDetails)
                {
                    this.tileDetails = new HashSet<ITileDetails>(tileDetails);
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