namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes
{
    /// <summary>
    /// Todo
    /// </summary>
    public enum GearSize
    {
        None,
        Small,
        Medium,
        Large,
        Omni
    }

    public static class EnumExtensions
    {
        public static string GetAbbr(this GearSize value)
        {
            switch (value)
            {
                case GearSize.Large:
                    return "(L)";

                case GearSize.Medium:
                    return "(M)";

                case GearSize.Small:
                    return "(S)";

                case GearSize.Omni:
                    return "(O)";

                default:
                    return "(null)";
            }
        }
    }
}