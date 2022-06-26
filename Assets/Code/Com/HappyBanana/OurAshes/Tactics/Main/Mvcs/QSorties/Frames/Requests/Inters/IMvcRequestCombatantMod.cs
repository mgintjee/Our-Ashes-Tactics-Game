using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.IDs;

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