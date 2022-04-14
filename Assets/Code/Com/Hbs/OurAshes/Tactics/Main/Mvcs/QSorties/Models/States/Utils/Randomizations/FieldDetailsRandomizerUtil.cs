using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils
{
    public class FieldDetailsRandomizerUtil
    {
        public static IFieldDetails Randomize(Random random)
        {
            FieldID fieldID = EnumUtils.GenerateRandomEnum<FieldID>(random);
            return GetFieldDetails(random, fieldID);
        }

        public static IFieldDetails GetFieldDetails(Random random, FieldID fieldID)
        {
            if (fieldID == FieldID.Random)
            {
                return GetRandomFieldDetails(random);
            }
            else
            {
                return FieldDetailsManager.GetFieldDetails(fieldID).GetValue();
            }
        }

        private static IFieldDetails GetRandomFieldDetails(Random random, FieldID fieldID, FieldBiome fieldBiome, FieldShape fieldShape, FieldSize fieldSize)
        {
            ISet<ITileDetails> tileDetails = GetRandomTileDetails(random, fieldShape, fieldSize);
            IFieldDetails fieldDetails = FieldDetailsImpl.Builder.Get()
                .SetFieldID(fieldID)
                .SetFieldBiome(fieldBiome)
                .SetFieldShape(fieldShape)
                .SetFieldSize(fieldSize)
                .SetTileDetails(tileDetails)
                .Build();
            return fieldDetails;
        }

        private static IFieldDetails GetRandomFieldDetails(Random random)
        {
            FieldBiome fieldBiome = EnumUtils.GenerateRandomEnum<FieldBiome>(random);
            FieldShape fieldShape = EnumUtils.GenerateRandomEnum<FieldShape>(random);
            FieldSize fieldSize = EnumUtils.GenerateRandomEnum<FieldSize>(random);
            return GetRandomFieldDetails(random, FieldID.Random, fieldBiome, fieldShape, fieldSize);
        }

        public static ISet<ITileDetails> GetRandomTileDetails(Random random, FieldShape fieldShape, FieldSize fieldSize)
        {
            IDictionary<Vector3, ITileDetails> tileCoordDetails = new Dictionary<Vector3, ITileDetails>();

            bool isMapMirrored = random.Next() % 2 == 0;
            TileCoordsAlgorithmsManager.GetTileCoordsAlgorithm(fieldShape).IfPresent(tileCoordsAlgorithm =>
            {
                ISet<Vector3> tileCoords = tileCoordsAlgorithm.GetTileCoords(fieldShape, fieldSize);

                foreach(Vector3 tileCoord in tileCoords)
                {
                    BuildRandomTileDetails(random, tileCoordDetails, isMapMirrored, tileCoord);
                }
            });

            return new HashSet<ITileDetails>( tileCoordDetails.Values);
        }

        private static void BuildRandomTileDetails(Random random, IDictionary<Vector3, ITileDetails> tileCoordDetails, bool isMapMirrored, Vector3 tileCoord)
        {
            if(isMapMirrored && tileCoordDetails.ContainsKey(tileCoord * -1))
            {
                ITileDetails tileDetails = tileCoordDetails[tileCoord * -1];
                ITileDetails mirroredTileDetails = TileDetailsImpl.Builder.Get()
                    .SetTileType(tileDetails.GetTileType())
                    .SetVector3(tileCoord)
                    .Build();
                tileCoordDetails.Add(tileCoord, mirroredTileDetails);
            }

            if(!tileCoordDetails.ContainsKey(tileCoord))
            {
                tileCoordDetails.Add(tileCoord, BuildRandomTileDetails(random, tileCoord));
            }
        }

        private static ITileDetails BuildRandomTileDetails(Random random, Vector3 tileCoord)
        {
            TileType tileType = EnumUtils.GenerateRandomEnum<TileType>(random);
            return TileDetailsImpl.Builder.Get()
                .SetTileType(tileType)
                .SetVector3(tileCoord)
                .Build();
        }
    }
}