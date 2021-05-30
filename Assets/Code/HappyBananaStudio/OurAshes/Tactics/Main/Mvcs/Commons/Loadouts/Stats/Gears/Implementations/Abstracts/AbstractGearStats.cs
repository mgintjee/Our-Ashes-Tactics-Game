using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Gears.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Views.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Stats.Gears.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Gear Stats Implementation
    /// </summary>
    public class AbstractGearStats
        : IGearStats
    {
        // Todo
        protected GearID _gearID;

        // Todo
        protected IGearModelStats _gearModelStats;

        // Todo
        protected IGearViewStats _gearViewStats;

        // Todo
        protected string _name;

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <inheritdoc/>
        GearID IGearStats.GetGearID()
        {
            return _gearID;
        }

        /// <inheritdoc/>
        IGearModelStats IGearStats.GetGearModelStats()
        {
            return _gearModelStats;
        }

        /// <inheritdoc/>
        IGearViewStats IGearStats.GetGearViewStats()
        {
            return _gearViewStats;
        }

        /// <inheritdoc/>
        string IGearStats.GetName()
        {
            return _name;
        }
    }
}