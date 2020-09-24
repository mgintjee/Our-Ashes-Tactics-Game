/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.ResourceLoader;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Impl;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Util
{
    public static class HexTileObjectBuilderUtil
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileConstructionReport"></param>
        /// <returns></returns>
        public static IHexTileObject BuildHexTileObject(HexTileConstructionReport hexTileConstructionReport)
        {
            // Check that the HexTileConstructionReport is non-null
            if (hexTileConstructionReport != null)
            {
                // Spawn the GameObject
                GameObject hexTileGameObject = GameObjectResourceLoader.HexTiles
                    .LoadHexTileGameObjectResource();
                // Add the HexTileScript to the GameObject
                HexTileScript hexTileScript = hexTileGameObject.AddComponent<HexTileScriptImpl>();
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

        #endregion Public Methods
    }
}