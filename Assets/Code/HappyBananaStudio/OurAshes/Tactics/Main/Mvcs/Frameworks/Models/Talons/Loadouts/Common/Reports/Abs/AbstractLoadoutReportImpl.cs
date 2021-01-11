using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Reports.Abs
{
    /// <summary>
    /// Loadout Report Api
    /// </summary>
    public abstract class AbstractLoadoutReportImpl
        : ILoadoutReport
    {
        // Todo
        protected ILoadoutAttributes loadoutAttributes = null;

        // Todo
        protected LoadoutRarity loadoutRarity = LoadoutRarity.None;

        /// <inheritdoc/>
        ILoadoutAttributes ILoadoutReport.GetLoadoutAttributes()
        {
            return this.loadoutAttributes;
        }

        /// <inheritdoc/>
        LoadoutRarity ILoadoutReport.GetLoadoutRarity()
        {
            return this.loadoutRarity;
        }
    }
}