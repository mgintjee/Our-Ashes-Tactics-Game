namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.GameBoards.Coordinates.Cube
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class TalonSpawnCubeCoordinatesGenerator
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxReports"></param>
        /// <param name="cubeCoordinatesSet"></param>
        /// <returns></returns>
        public static IDictionary<TalonCallSign, ICubeCoordinates> GenerateSpawnCubeCoordinates(
            ISet<IPhalanxReport> phalanxReports, ISet<ICubeCoordinates> cubeCoordinatesSet)
        {
            IDictionary<TalonCallSign, ICubeCoordinates> talonSpawnCubeCoordinatesDictionary =
                new Dictionary<TalonCallSign, ICubeCoordinates>();
            foreach (IPhalanxReport phalanxReport in phalanxReports)
            {
                foreach (TalonCallSign talonCallSign in phalanxReport.GetTalonCallSigns())
                {
                    // Todo: Determine the best way of creating the spawn coordinates
                    ICubeCoordinates cubeCoordinates = null;
                    while (cubeCoordinates == null)
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