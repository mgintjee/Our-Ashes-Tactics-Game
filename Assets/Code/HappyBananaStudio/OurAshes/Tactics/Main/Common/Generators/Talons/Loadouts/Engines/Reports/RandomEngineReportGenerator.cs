using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Randoms.Generators.Numbers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Traits.Reports.Impl;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Loadouts.Engines.Reports
{
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
            if (engineIdSet.Count != 0)
            {
                return new List<EngineId>(engineIdSet)[RandomNumberGeneratorUtil.GetNextInt(engineIdSet.Count)];
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?s.",
                    new StackFrame().GetMethod().Name, loadoutRarity, typeof(EngineId));
        }
    }
}