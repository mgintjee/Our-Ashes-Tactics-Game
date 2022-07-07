using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Details.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcRequestUnitMod
        : IMvcRequestMod
    {
        PhalanxID GetPhalanxID();

        IUnitDetails GetUnitDetails();
    }
}