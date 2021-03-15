using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.GameBoards.Coordinates.Cube
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CubeCoordinatesSetGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardShape"></param>
        /// <returns></returns>
        public static ISet<ICubeCoordinates> GenerateCubeCoordinates(GameBoardShape gameBoardShape, int gameBoardLimit)
        {
            ISet<ICubeCoordinates> cubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            switch (gameBoardShape)
            {
                case GameBoardShape.Hexagon:
                    cubeCoordinatesSet = GenerateCubeCoordinatesForHexagon(gameBoardLimit);
                    break;

                default:
                    break;
            }
            return cubeCoordinatesSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardLimit"></param>
        /// <returns></returns>
        private static ISet<ICubeCoordinates> GenerateCubeCoordinatesForHexagon(int gameBoardLimit)
        {
            ISet<ICubeCoordinates> cubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            ISet<ICubeCoordinates> visitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>();
            ISet<ICubeCoordinates> unvisitedCubeCoordinatesSet = new HashSet<ICubeCoordinates>
                { new CubeCoordinates(0, 0, 0)};
            while (unvisitedCubeCoordinatesSet.Count > 0)
            {
                ICubeCoordinates currentCubeCoordinates = new List<ICubeCoordinates>(unvisitedCubeCoordinatesSet)[0];
                unvisitedCubeCoordinatesSet.Remove(currentCubeCoordinates);
                cubeCoordinatesSet.Add(currentCubeCoordinates);
                if (!visitedCubeCoordinatesSet.Contains(currentCubeCoordinates))
                {
                    visitedCubeCoordinatesSet.Add(currentCubeCoordinates);
                }

                ISet<ICubeCoordinates> neighborCubeCoordinates = CubeCoordinatesCommonUtil.GenerateNeighborCubeCoordinatesSet(
                    currentCubeCoordinates, gameBoardLimit);
                foreach (ICubeCoordinates cubeCoordinates in neighborCubeCoordinates)
                {
                    if (!visitedCubeCoordinatesSet.Contains(cubeCoordinates) &&
                        CubeCoordinatesCommonUtil.GetCubeCoordinatesDistanceFromCenter(cubeCoordinates) <= gameBoardLimit)
                    {
                        unvisitedCubeCoordinatesSet.Add(cubeCoordinates);
                    }
                }
            }
            return cubeCoordinatesSet;
        }
    }
}