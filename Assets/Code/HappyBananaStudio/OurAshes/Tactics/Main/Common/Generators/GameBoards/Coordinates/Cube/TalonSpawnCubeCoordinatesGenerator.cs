using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Randoms.Generators.Numbers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.GameBoards.Coordinates.Cube
{
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