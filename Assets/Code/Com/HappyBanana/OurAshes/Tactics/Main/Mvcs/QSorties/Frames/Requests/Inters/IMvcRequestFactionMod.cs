using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcRequestFactionMod
        : IMvcRequestMod
    {
        FactionID GetFactionID();
    }
}