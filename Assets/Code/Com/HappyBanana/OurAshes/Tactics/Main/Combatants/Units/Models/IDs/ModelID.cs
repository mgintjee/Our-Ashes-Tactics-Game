using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Icons.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.IDs
{
    /// <summary>
    /// Todo
    /// </summary>
    public enum ModelID
    {
        None,
        MAA,
        MBA,
        MCA,
    }

    public static class Extensions
    {
        public static IconID GetIconID(this ModelID value)
        {
            switch (value)
            {
                case ModelID.MAA:
                    return IconID.UnitModelMaa;

                case ModelID.MBA:
                    return IconID.UnitModelMba;

                case ModelID.MCA:
                    return IconID.UnitModelMca;

                default:
                    return IconID.None;
            }
        }
    }
}