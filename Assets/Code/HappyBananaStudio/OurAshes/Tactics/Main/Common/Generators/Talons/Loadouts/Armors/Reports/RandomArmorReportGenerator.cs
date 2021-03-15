using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Randoms.Generators.Numbers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Utils.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Constants;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Traits.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Armors.Traits.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Common.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Loadouts.Armors.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomArmorReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static IArmorReport GenerateRandomArmorReport(LoadoutRarity loadoutRarity)
        {
            ArmorId armorId = GetRandomArmorId(loadoutRarity);
            // Todo: Only randomize traits for non-unique loadouts
            ArmorTraitMaterial armorTraitMaterial = ArmorTraitMaterial.None;
            ArmorTraitStructure armorTraitStructure = ArmorTraitStructure.None;
            int traitsRequired = ArmorRarityConstants.GetLoadoutTraitCount(loadoutRarity);
            float traitsRemaining = 4f;

            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                armorTraitMaterial = EnumUtils.GetRandomEnum<ArmorTraitMaterial>();
                traitsRequired--;
            }
            traitsRemaining--;
            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                armorTraitStructure = EnumUtils.GetRandomEnum<ArmorTraitStructure>();
            }

            return new ArmorReport.Builder()
                .SetArmorId(armorId)
                .SetArmorTraitReport(new ArmorTraitReport.Builder()
                    .SetArmorTraitMaterial(armorTraitMaterial)
                    .SetArmorTraitStructure(armorTraitStructure)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        private static ArmorId GetRandomArmorId(LoadoutRarity loadoutRarity)
        {
            ISet<ArmorId> armorIdSet = ArmorRarityConstants.GetArmorIdSet(loadoutRarity);
            if (armorIdSet.Count != 0)
            {
                return new List<ArmorId>(armorIdSet)[RandomNumberGeneratorUtil.GetNextInt(armorIdSet.Count)];
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?s.",
                    new StackFrame().GetMethod().Name, loadoutRarity, typeof(ArmorId));
        }
    }
}