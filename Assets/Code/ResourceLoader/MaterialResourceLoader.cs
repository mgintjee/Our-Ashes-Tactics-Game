using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MaterialResourceLoader
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo: Store somewhere else. Maybe in a Resources File Structure class
    private static readonly string MATERIALS_FOLDER_HOME = "Materials/";

    // Todo: Store somewhere else. Maybe in a Resources File Structure class
    private static readonly string NULL_MATERIAL_PATH = MATERIALS_FOLDER_HOME + "MaterialNull";

    #endregion Private Fields

    #region Private Methods

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

    #endregion Private Methods

    #region Public Classes

    public class HexTile
    {
        #region Private Fields

        // Todo
        private static readonly string HEX_TILE_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "TileMaterials/";

        #endregion Private Fields

        #region Public Classes

        public class Base
        {
            #region Private Fields

            private static readonly string MATERIAL_PREFIX = "TileBase_";

            private static readonly string TILE_MATERIALS_BASE_FOLDER_HOME = HEX_TILE_MATERIALS_FOLDER_HOME + "Base/";

            #endregion Private Fields
        }

        public class Top
        {
            #region Private Fields

            private static readonly string MATERIAL_PREFIX = "TileTop_";

            private static readonly string TILE_MATERIALS_TOP_FOLDER_HOME = HEX_TILE_MATERIALS_FOLDER_HOME + "Top/";

            #endregion Private Fields

            #region Public Methods

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

            #endregion Public Methods
        }

        #endregion Public Classes
    }

    public class Paint
    {
        #region Private Fields

        private static readonly string MATERIAL_PREFIX = "Paint_";

        // Todo
        private static readonly string PAINT_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "PaintMaterials/";

        #endregion Private Fields

        #region Public Methods

        public static Material LoadPaintMaterialResource(TalonColorIdEnum paintColor)
        {
            return LoadMaterialResource(PAINT_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + paintColor.ToString());
        }

        #endregion Public Methods
    }

    public class Path
    {
        #region Private Fields

        private static readonly string MATERIAL_PREFIX = "PathType_";

        // Todo
        private static readonly string PATH_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "PathMaterials/";

        #endregion Private Fields

        #region Public Methods

        public static Material LoadPathMaterialResource(TalonActionTypeEnum mechActionType)
        {
            string mechActionTypeString = "";
            switch (mechActionType)
            {
                case TalonActionTypeEnum.Fire:
                    mechActionTypeString = "Fire";
                    break;

                case TalonActionTypeEnum.Move:
                    mechActionTypeString = "Move";
                    break;

                case TalonActionTypeEnum.Wait:
                    mechActionTypeString = "Wait";
                    break;
            }
            return LoadMaterialResource(PATH_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + mechActionTypeString);
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}