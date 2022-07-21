using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs
{
    /// <summary>
    /// Todo
    /// </summary>
    public enum FactionID
    {
        None,
        Unaone,
        Bissotwo,
        Terrathree,
        Freelance
    }

    public static class Extensions
    {
        public static IconID GetIconID(this FactionID value)
        {
            switch (value)
            {
                case FactionID.Unaone:
                    return IconID.FactionUO;

                case FactionID.Bissotwo:
                    return IconID.FactionBT;

                case FactionID.Terrathree:
                    return IconID.FactionTT;

                case FactionID.Freelance:
                    return IconID.FactionFL;

                default:
                    return IconID.None;
            }
        }
        public static PatternID GetPatternID(this FactionID value)
        {
            switch (value)
            {
                case FactionID.Unaone:
                    return PatternID.FactionUO;

                case FactionID.Bissotwo:
                    return PatternID.FactionBT;

                case FactionID.Terrathree:
                    return PatternID.FactionTT;

                case FactionID.Freelance:
                    return PatternID.FactionFL;

                default:
                    return PatternID.None;
            }
        }
    }
}