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
        Large
    }

    public static class Extensions
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

                default:
                    return "(null)";
            }
        }
    }
}