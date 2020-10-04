/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Scripts.HexTiles;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.HexTiles
{
    public static class HexTileObjectBuilderUtil
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static IHexTileObject BuildHexTileObject(IHexTileConstructionReport hexTileConstructionReport)
        {
            // Check that the HexTileConstructionReport is non-null
            if (hexTileConstructionReport != null)
            {
                // Spawn the GameObject
                GameObject hexTileGameObject = GameObjectResourceLoader.HexTiles
                    .LoadHexTileGameObjectResource();
                // Add the HexTileScript to the GameObject
                IHexTileScript hexTileScript = hexTileGameObject.AddComponent<HexTileScriptImpl>();
                // Initialize the HexTileScript with the HexTileConstructionReport
                hexTileScript.Initialize(hexTileConstructionReport);
                // Return the HexTileObject
                return hexTileScript.GetHexTileObject();
            }
            else
            {
                logger.Error("Unable to build ?. Invalid Parameters.", typeof(IHexTileObject));
                return null;
            }
        }
    }
}