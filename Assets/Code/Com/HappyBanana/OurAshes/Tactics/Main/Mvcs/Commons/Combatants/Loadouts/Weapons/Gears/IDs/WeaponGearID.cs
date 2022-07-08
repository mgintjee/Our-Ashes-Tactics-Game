namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs
{
    /// <summary>
    /// ArmorGear ID Enum
    /// </summary>
    public enum WeaponGearID
    {
        None,
        WBA, // Bolf from the Blue
        WAA, // Bunch of Fives
        WCA, // Country Miles
    }

    public static class Extensions
    {
        public static string GetString(this WeaponGearID me)
        {
            switch (me)
            {
                case WeaponGearID.None:
                    return "none";

                case WeaponGearID.WAA:
                    return "Bunch of Fives";

                default:
                    return "NO VALUE GIVEN";
            }
        }
    }
}