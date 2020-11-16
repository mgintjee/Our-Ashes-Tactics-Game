namespace HappyBananaStudio.OurAshes.Tactics.Common.Generators.Reports.MVCs.Initialization
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Coordinates;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.Initializers.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Reports;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomMvcInitializationReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static IMvcInitializationReport GenerateRandomMvcInitializationReport()
        {
            ISet<ICubeCoordinates> cubeCoordinatesSet = CubeCoordinatesGeneratorUtil.GenerateHexagonCubeCoordinatesSet(RandomNumberGeneratorUtil.GetNextInt(2, 4));
            return new MvcInitializationReportImpl.Builder()
                .SetGameMapConstructionReport(new GameMapConstructionReportImpl.Builder()
                    .SetCubeCoordinatesSet(cubeCoordinatesSet)
                    .SetMapMirrored(RandomNumberGeneratorUtil.GetNextInt() % 2 == 0)
                    .Build())
                .SetRosterConstructionReport(GenerateRandomRosterConstructionReport(cubeCoordinatesSet.Count))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameMapCount">
        /// </param>
        /// <returns>
        /// </returns>
        private static IDictionary<FactionId, ISet<PhalanxId>> GenerateRandomFactionIdPhalanxIdSet(int gameMapCoordinatesCount)
        {
            IDictionary<FactionId, ISet<PhalanxId>> factionIdPhalanxIdSetDictionary = new Dictionary<FactionId, ISet<PhalanxId>>();
            int maxTalonCount = (int)Math.Floor(gameMapCoordinatesCount / 5f);
            return factionIdPhalanxIdSetDictionary;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private static IRosterConstructionReport GenerateRandomRosterConstructionReport(int gameMapCoordinatesCount)
        {
            return new RosterConstructionReportImpl.Builder()
                .SetFactionIdPhalanxIdSetDictionary(GenerateRandomFactionIdPhalanxIdSet(gameMapCoordinatesCount))
                .SetPhalanxIdTalonConstructionReportDictionary(null)
                .Build();
        }
    }
}
