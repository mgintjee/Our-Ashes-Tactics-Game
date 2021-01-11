namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.GameBoards.Coordinates.Cube
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonSpawnCubeCoordinatesGenerator
    {
        public static IDictionary<TalonCallSign, ICubeCoordinates> GenerateSpawnCubeCoordinates(
            ISet<ISet<TalonCallSign>> talonCallSignSets, ISet<ICubeCoordinates> cubeCoordinatesSet)
        {
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary =
                new Dictionary<TalonCallSign, ICubeCoordinates>();
            foreach (ISet<TalonCallSign> talonCallSignSet in talonCallSignSets)
            {
                foreach (TalonCallSign talonCallSign in talonCallSignSet)
                {
                    // Todo: Determine the best way of creating the spawn coordinates
                    ICubeCoordinates cubeCoordinates = null;
                    while (cubeCoordinates != null)
                    {
                        cubeCoordinates = new List<ICubeCoordinates>(cubeCoordinatesSet)
                            [RandomNumberGeneratorUtil.GetNextInt(cubeCoordinatesSet.Count)];
                        if (talonSpawnCubeCoordinatesDictionary.Values.Contains(cubeCoordinates))
                        {
                            cubeCoordinates = null;
                        }
                    }
                    talonSpawnCubeCoordinatesDictionary[talonCallSign] = cubeCoordinates;
                }
            }
            return talonSpawnCubeCoordinatesDictionary;
        }
    }
}