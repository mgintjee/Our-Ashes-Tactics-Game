namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Loadouts.Engines.Reports
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Reports.Impl;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomEngineReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static IEngineReport GenerateRandomEngineReport(LoadoutRarity loadoutRarity)
        {
            EngineId engineId = GetRandomEngineId(loadoutRarity);
            // Todo: Only randomize traits for non-unique loadouts
            EngineTraitEfficiency engineTraitEfficiency = EngineTraitEfficiency.None;
            EngineTraitStructure engineTraitStructure = EngineTraitStructure.None;
            int traitsRequired = EngineRarityConstants.GetLoadoutTraitCount(loadoutRarity);
            float traitsRemaining = 4f;

            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                engineTraitEfficiency = EnumUtils.GetRandomEnum<EngineTraitEfficiency>();
                traitsRequired--;
            }
            traitsRemaining--;
            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                engineTraitStructure = EnumUtils.GetRandomEnum<EngineTraitStructure>();
            }
            return new EngineReport.Builder()
                .SetEngineId(engineId)
                .SetEngineTraitReport(new EngineTraitReport.Builder()
                    .SetEngineTraitEfficiency(engineTraitEfficiency)
                    .SetEngineTraitStructure(engineTraitStructure)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private static EngineId GetRandomEngineId(LoadoutRarity loadoutRarity)
        {
            ISet<EngineId> engineIdSet = EngineRarityConstants.GetEngineIdSet(loadoutRarity);
            if (engineIdSet.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?s.",
                        new StackFrame().GetMethod().Name, loadoutRarity, typeof(EngineId));
            }
            return new List<EngineId>(engineIdSet)[RandomNumberGeneratorUtil.GetNextInt(engineIdSet.Count)];
        }
    }
}