using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class FieldDetailsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static IFieldDetails Randomize(Random random)
        {
            FieldID fieldID = EnumUtils.GenerateRandomEnum<FieldID>(random);
            IFieldDetails details = GetFieldDetails(random, fieldID);
            logger.Info("Randomized: {}", details);
            return details;
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

        public static IList<ITileDetails> GetRandomTileDetails(Random random, FieldShape fieldShape, FieldSize fieldSize)
        {
            IDictionary<Vector3, ITileDetails> tileCoordDetails = new Dictionary<Vector3, ITileDetails>();

            bool isMapMirrored = random.Next() % 2 == 0;
            TileCoordsAlgorithmsManager.GetTileCoordsAlgorithm(fieldShape).IfPresent(tileCoordsAlgorithm =>
            {
                IList<Vector3> tileCoords = tileCoordsAlgorithm.GetTileCoords(fieldShape, fieldSize);

                logger.Debug("Generated {} for {}", tileCoords, fieldShape);
                foreach (Vector3 tileCoord in tileCoords)
                {
                    BuildRandomTileDetails(random, tileCoordDetails, isMapMirrored, tileCoord);
                }
            });
            logger.Debug("From {}, {}, Generated {}", fieldShape, fieldSize, tileCoordDetails);

            return new List<ITileDetails>(tileCoordDetails.Values);
        }

        private static IFieldDetails GetRandomFieldDetails(Random random, FieldID fieldID, FieldBiome fieldBiome, FieldShape fieldShape, FieldSize fieldSize)
        {
            IList<ITileDetails> tileDetails = GetRandomTileDetails(random, fieldShape, fieldSize);
            IFieldDetails fieldDetails = FieldDetailsImpl.Builder.Get()
                .SetFieldID(fieldID)
                .SetFieldBiome(fieldBiome)
                .SetFieldShape(fieldShape)
                .SetFieldSize(fieldSize)
                .SetTileDetails(tileDetails)
                .Build();
            logger.Debug("Generated {}", fieldDetails);
            return fieldDetails;
        }

        private static IFieldDetails GetRandomFieldDetails(Random random)
        {
            FieldBiome fieldBiome = EnumUtils.GenerateRandomEnum<FieldBiome>(random);
            FieldShape fieldShape = EnumUtils.GenerateRandomEnum<FieldShape>(random);
            FieldSize fieldSize = EnumUtils.GenerateRandomEnum<FieldSize>(random);
            return GetRandomFieldDetails(random, FieldID.Random, fieldBiome, fieldShape, fieldSize);
        }

        private static void BuildRandomTileDetails(Random random, IDictionary<Vector3, ITileDetails> tileCoordDetails, bool isMapMirrored, Vector3 tileCoords)
        {
            if (isMapMirrored && tileCoordDetails.ContainsKey(tileCoords * -1))
            {
                ITileDetails tileDetails = tileCoordDetails[tileCoords * -1];
                ITileDetails mirroredTileDetails = TileDetailsImpl.Builder.Get()
                    .SetTileType(tileDetails.GetTileType())
                    .SetVector3(tileCoords)
                    .Build();
                tileCoordDetails.Add(tileCoords, mirroredTileDetails);
            }

            logger.Debug("Building details for {}", tileCoords);
            if (!tileCoordDetails.ContainsKey(tileCoords))
            {
                tileCoordDetails.Add(tileCoords, BuildRandomTileDetails(random, tileCoords));
            }
        }

        private static ITileDetails BuildRandomTileDetails(Random random, Vector3 tileCoord)
        {
            TileType tileType = EnumUtils.GenerateRandomEnum<TileType>(random);
            logger.Debug("Coord: {}, {}", tileCoord, tileType);
            return TileDetailsImpl.Builder.Get()
                .SetTileType(tileType)
                .SetVector3(tileCoord)
                .Build();
        }
    }
}