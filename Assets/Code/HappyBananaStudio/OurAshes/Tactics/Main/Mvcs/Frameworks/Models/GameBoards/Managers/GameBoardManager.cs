namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// GameBoard Manager
    /// </summary>
    public class GameBoardManager
    {
        // Todo
        private static IGameBoardObject gameBoardObject;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static float FindHexTileObjectFireCostFrom(ICubeCoordinates cubeCoordinates)
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetHexTileObjectFireCostFrom(cubeCoordinates);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GetAllCubeCoordinatesSet()
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetCubeCoordinatesSet();
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGameBoardReport GetGameBoardReport()
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetGameBoardReport();
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static IHexTileObject GetHexTileObjectFrom(ICubeCoordinates cubeCoordinates)
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetHexTileObject(cubeCoordinates);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        public static ISet<ICubeCoordinates> GetNeighborCubeCoordinates(ICubeCoordinates cubeCoordinates)
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetNeighborCubeCoordinates(cubeCoordinates);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardObject">
        /// </param>
        public static void SetGameBoardObject(IGameBoardObject gameBoardObject)
        {
            if (GameBoardManager.gameBoardObject == null)
            {
                GameBoardManager.gameBoardObject = gameBoardObject;
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }
    }
}