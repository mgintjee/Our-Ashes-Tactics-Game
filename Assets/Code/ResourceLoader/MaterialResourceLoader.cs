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

    public class Paint
    {
        #region Private Fields

        private static readonly string MATERIAL_PREFIX = "Paint_";

        // Todo
        private static readonly string PAINT_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "PaintMaterials/";

        #endregion Private Fields

        #region Public Methods

        public static Material LoadPaintMaterialResource(PaintColorEnum paintColor)
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

        public static Material LoadPathMaterialResource(MechActionTypeEnum mechActionType)
        {
            string mechActionTypeString = "";
            switch (mechActionType)
            {
                case MechActionTypeEnum.Fire:
                    mechActionTypeString = "Fire";
                    break;

                case MechActionTypeEnum.Move:
                    mechActionTypeString = "Move";
                    break;

                case MechActionTypeEnum.Wait:
                    mechActionTypeString = "Wait";
                    break;
            }
            return LoadMaterialResource(PATH_MATERIALS_FOLDER_HOME + MATERIAL_PREFIX + mechActionTypeString);
        }

        #endregion Public Methods
    }

    public class Tile
    {
        #region Private Fields

        // Todo
        private static readonly string TILE_MATERIALS_FOLDER_HOME = MATERIALS_FOLDER_HOME + "TileMaterials/";

        #endregion Private Fields

        #region Public Classes

        public class Base
        {
            #region Private Fields

            private static readonly string MATERIAL_PREFIX = "TileBase_";

            private static readonly string TILE_MATERIALS_BASE_FOLDER_HOME = TILE_MATERIALS_FOLDER_HOME + "Base/";

            #endregion Private Fields
        }

        public class Top
        {
            #region Private Fields

            private static readonly string MATERIAL_PREFIX = "TileTop_";

            private static readonly string TILE_MATERIALS_TOP_FOLDER_HOME = TILE_MATERIALS_FOLDER_HOME + "Top/";

            #endregion Private Fields

            #region Public Methods

            public static Material LoadTileTopMaterialResource(TileObjectTypeEnum tileObjectType)
            {
                string mechActionTypeString = "";
                switch (tileObjectType)
                {
                    case TileObjectTypeEnum.Forest:
                        mechActionTypeString = "Forest";
                        break;

                    case TileObjectTypeEnum.Mountain:
                        mechActionTypeString = "Mountains";
                        break;

                    case TileObjectTypeEnum.Plains:
                        mechActionTypeString = "Plains";
                        break;

                    case TileObjectTypeEnum.Road:
                        mechActionTypeString = "Road";
                        break;

                    case TileObjectTypeEnum.Water:
                        mechActionTypeString = "Water";
                        break;
                }
                return LoadMaterialResource(TILE_MATERIALS_TOP_FOLDER_HOME + MATERIAL_PREFIX + mechActionTypeString);
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }

    #endregion Public Classes
}