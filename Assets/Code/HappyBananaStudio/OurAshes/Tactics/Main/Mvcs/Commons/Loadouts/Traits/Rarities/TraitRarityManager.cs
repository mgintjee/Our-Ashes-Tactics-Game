using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loadouts.Traits.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Rarities.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Stats.Managers;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Rarities
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TraitRarityManager
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="traitID"></param>
        /// <returns></returns>
        public static float GetValue(TraitID traitID)
        {
            float value = 0.0f;

            TraitStatsManager.GetStats(traitID).IfPresent(traitStats =>
            {
                switch (traitStats.GetRarity())
                {
                    case Rarity.Common:
                        value = 1.0f;
                        break;

                    case Rarity.Uncommon:
                        value = 2.0f;
                        break;

                    case Rarity.Epic:
                        value = 3.0f;
                        break;

                    case Rarity.Unique:
                        value = 5.0f;
                        break;
                }
            });

            return value;
        }
    }
}