using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcRequestCombatantMod
        : IMvcRequestMod
    {
        CallSign GetPhalanxCallSign();

        ICombatantDetails GetCombatantDetails();
    }
}