/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MaterialResourceLoader
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static readonly string MATERIALS_FOLDER_HOME = "Materials/";

        // Todo
        private static readonly string NULL_MATERIAL_PATH = MATERIALS_FOLDER_HOME + "MaterialNull";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="materialPath">
        /// </param>
        /// <returns>
        /// </returns>
        private static Material LoadMaterialResource(string materialPath)
        {
            Material material = Resources.Load<Material>(materialPath);
            if (material == null)
            {
                logger.Warn("Failed to load material with Path=?", materialPath);
                material = Resources.Load<Material>(NULL_MATERIAL_PATH);
            }
            return material;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class HexTile
        {
            // Todo
            private static readonly string HEX_TILE_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "TileMaterials/";

            /// <summary>
            /// Todo
            /// </summary>
            public class Base
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            public class Top
            {
                // Todo
                private static readonly string MATERIAL_PREFIX = "TileTop_";

                // Todo
                private static readonly string TILE_MATERIALS_TOP_FOLDER_HOME = HEX_TILE_MATERIALS_FOLDER_HOME + "Top/";

                /// <summary>
                /// Todo
                /// </summary>
                /// <param name="hexTileObjectType">
                /// </param>
                /// <returns>
                /// </returns>
                public static Material LoadHexTileTopMaterialResource(HexTileTypeEnum hexTileObjectType)
                {
                    string mechActionTypeString = "";
                    switch (hexTileObjectType)
                    {
                        case HexTileTypeEnum.Forest:
                            mechActionTypeString = "Forest";
                            break;

                        case HexTileTypeEnum.Mountain:
                            mechActionTypeString = "Mountains";
                            break;

                        case HexTileTypeEnum.Plains:
                            mechActionTypeString = "Plains";
                            break;

                        case HexTileTypeEnum.Road:
                            mechActionTypeString = "Road";
                            break;

                        case HexTileTypeEnum.Water:
                            mechActionTypeString = "Water";
                            break;
                    }
                    return LoadMaterialResource(TILE_MATERIALS_TOP_FOLDER_HOME + MATERIAL_PREFIX + mechActionTypeString);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Paint
        {
            // Todo
            private static readonly string MATERIAL_PREFIX = "Paint_";

            // Todo
            private static readonly string PAINT_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "PaintMaterials/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="paintColor">
            /// </param>
            /// <returns>
            /// </returns>
            public static Material LoadPaintMaterialResource(PaintColorIdEnum paintColor)
            {
                return LoadMaterialResource(PAINT_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + paintColor.ToString());
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Path
        {
            // Todo
            private static readonly string MATERIAL_PREFIX = "PathType_";

            // Todo
            private static readonly string PATH_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "PathMaterials/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mechActionType">
            /// </param>
            /// <returns>
            /// </returns>
            public static Material LoadPathMaterialResource(ActionTypeEnum mechActionType)
            {
                string mechActionTypeString = "";
                switch (mechActionType)
                {
                    case ActionTypeEnum.Fire:
                        mechActionTypeString = "Fire";
                        break;

                    case ActionTypeEnum.Move:
                        mechActionTypeString = "Move";
                        break;

                    case ActionTypeEnum.Wait:
                        mechActionTypeString = "Wait";
                        break;
                }
                return LoadMaterialResource(PATH_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + mechActionTypeString);
            }
        }
    }
}