namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Collections.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Collections.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Views.Api;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class HexTileViewCollectionManager
    {
        // Todo
        private static IHexTileViewCollection hexTileViewCollection;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="hexTileViewCollection"></param>
        public static void SetHexTileViewCollection(IHexTileViewCollection hexTileViewCollection)
        {
            if (HexTileViewCollectionManager.hexTileViewCollection == null)
            {
                HexTileViewCollectionManager.hexTileViewCollection = hexTileViewCollection;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(IHexTileViewCollection));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates"></param>
        /// <returns></returns>
        public static IHexTileView GetHexTileView(ICubeCoordinates cubeCoordinates)
        {
            if (hexTileViewCollection != null)
            {
                return hexTileViewCollection.GetHexTileView(cubeCoordinates);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IHexTileViewCollection));
            }
        }
    }
}