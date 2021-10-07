using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Views.Resources.Loaders.Materials
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
        /// <param name="colorID"></param>
        /// <returns></returns>
        public static Material LoadMaterialResource(ColorID colorID)
        {
            return LoadMaterialResource(ColorMaterialsFolderHome + colorID.ToString());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="materialPath"></param>
        /// <returns></returns>
        private static Material LoadMaterialResource(string materialPath)
        {
            Material material = UnityEngine.Resources.Load<Material>(materialPath);
            if (material == null)
            {
                material = UnityEngine.Resources.Load<Material>(NullMaterialPath);
            }
            return material;
        }
    }
}