namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Managers
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.HexTiles.Objects.Api;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Board Object Manager
    /// </summary>
    public class GameBoardObjectManager
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
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is null.",
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
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGameBoardReport GetBoardReport()
        {
            if (gameBoardObject != null)
            {
                return gameBoardObject.GetGameBoardReport();
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is null.",
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
                return gameBoardObject.GetHexTileObjectFrom(cubeCoordinates);
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is null.",
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
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is null.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardObject">
        /// </param>
        public static void SetBoardObject(IGameBoardObject gameBoardObject)
        {
            if (GameBoardObjectManager.gameBoardObject == null)
            {
                GameBoardObjectManager.gameBoardObject = gameBoardObject;
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is already set.",
                    new StackFrame().GetMethod().Name, typeof(IGameBoardObject));
            }
        }
    }
}