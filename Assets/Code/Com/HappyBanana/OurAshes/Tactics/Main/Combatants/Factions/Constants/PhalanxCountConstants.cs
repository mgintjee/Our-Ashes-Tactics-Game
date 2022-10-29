using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FactionCountConstants
    {
        public static readonly int MIN_COUNT = 1;
        private static readonly int SMALL_MAX_FACTION_COUNT = 1;
        private static readonly int MEDIUM_MAX_FACTION_COUNT = 2;
        private static readonly int LARGE_MAX_FACTION_COUNT = 3;

        public static int GetMaxCount(FieldSize fieldSize)
        {
            switch (fieldSize)
            {
                case FieldSize.Small:
                    return SMALL_MAX_FACTION_COUNT;

                case FieldSize.Medium:
                    return MEDIUM_MAX_FACTION_COUNT;

                case FieldSize.Large:
                    return LARGE_MAX_FACTION_COUNT;

                case FieldSize.None:
                default:
                    return 0;
            }
        }
    }
}