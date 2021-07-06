using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.ResourceLoaders.Materials
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MaterialResourceLoader
    {
        // Todo
        private static readonly string ColorMaterialsFolderHome = "Materials/Colors/";

        // Todo
        private static readonly string NullMaterialPath = ColorMaterialsFolderHome + "White";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        public static Material LoadMaterialResource(ColorID colorId)
        {
            return LoadMaterialResource(ColorMaterialsFolderHome + colorId.ToString());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="materialPath"></param>
        /// <returns></returns>
        private static Material LoadMaterialResource(string materialPath)
        {
            Material material = Resources.Load<Material>(materialPath);
            if (material == null)
            {
                material = Resources.Load<Material>(NullMaterialPath);
            }
            return material;
        }
    }
}