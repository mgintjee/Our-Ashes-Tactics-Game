namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.Materials
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.HexTiles.Common.Types.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Enums;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class MaterialResourceLoader
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

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
        public class Colors
        {
            // Todo
            private static readonly string Color_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "ColorMaterials/";

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="colorId">
            /// </param>
            /// <returns>
            /// </returns>
            public static Material LoadColorMaterialResource(ColorId colorId)
            {
                return LoadMaterialResource(Color_MATERIALS_FOLDER_HOME + colorId.ToString());
            }
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
                /// <param name="hexTileType">
                /// </param>
                /// <returns>
                /// </returns>
                public static Material LoadMaterial(HexTileType hexTileType)
                {
                    return LoadMaterialResource(TILE_MATERIALS_TOP_FOLDER_HOME + MATERIAL_PREFIX + hexTileType.ToString());
                }
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
            /// <param name="orderType">
            /// </param>
            /// <returns>
            /// </returns>
            public static Material LoadPathMaterialResource(OrderType orderType)
            {
                return LoadMaterialResource(PATH_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + orderType.ToString());
            }
        }
    }
}