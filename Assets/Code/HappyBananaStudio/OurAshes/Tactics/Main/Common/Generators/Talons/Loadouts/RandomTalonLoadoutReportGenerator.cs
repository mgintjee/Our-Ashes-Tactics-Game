namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Generators.Talons.Loadouts
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Attributes.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Impl;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomTalonLoadoutReportGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ITalonLoadoutReport GenerateRandomTalonLoadoutReport(TalonId talonId)
        {
            IList<MountSize> mountSizeList = TalonLoadoutAttributesConstants
                .GetTalonLoadoutAttributes(talonId).GetMountSizeList();
            return new TalonLoadoutReport.Builder()
                .SetTalonId(talonId)
                .SetArmorReport(RandomArmorReportGenerator.GenerateRandomArmorReport(LoadoutRarity.Common))
                .SetEngineReport(RandomEngineReportGenerator.GenerateRandomEngineReport(LoadoutRarity.Common))
                .SetMountReportList(GenerateRandomMountReportList(mountSizeList))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mountSizeList"></param>
        /// <returns></returns>
        private static IList<IMountReport> GenerateRandomMountReportList(IList<MountSize> mountSizeList)
        {
            IList<IMountReport> mountReportList = new List<IMountReport>();
            foreach (MountSize mountSize in mountSizeList)
            {
                LoadoutRarity loadoutRarity = LoadoutRarity.Common;
                if (RandomNumberGeneratorUtil.GetNextDouble() < 0.75f)
                {
                    mountReportList.Add(RandomWeaponReportGenerator.GenerateRandomWeaponReport(loadoutRarity, mountSize));
                }
                else
                {
                    mountReportList.Add(RandomUtilityReportGenerator.GenerateRandomUtilityReport(loadoutRarity, mountSize));
                }
            }
            return mountReportList;
        }
    }
}