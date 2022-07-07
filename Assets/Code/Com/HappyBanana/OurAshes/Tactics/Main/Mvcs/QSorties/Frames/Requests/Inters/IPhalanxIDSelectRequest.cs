using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxIDSelectRequest
        : IMvcRequest
    {
        PhalanxID GetPhalanxID();
    }
}