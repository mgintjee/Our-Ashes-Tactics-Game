namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Armors.Reports
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Armors.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

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
            int traitsRemaining = 2;

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

            return new ArmorReportImpl.Builder()
                .SetArmorId(armorId)
                .SetArmorTraitMaterial(armorTraitMaterial)
                .SetArmorTraitStructure(armorTraitStructure)
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
            if (armorIdSet.Count == 0)
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? has no corresponding ?s.",
                        new StackFrame().GetMethod().Name, loadoutRarity, typeof(ArmorId));
            }
            return new List<ArmorId>(armorIdSet)[RandomNumberGeneratorUtil.GetNextInt(armorIdSet.Count)];
        }
    }
}