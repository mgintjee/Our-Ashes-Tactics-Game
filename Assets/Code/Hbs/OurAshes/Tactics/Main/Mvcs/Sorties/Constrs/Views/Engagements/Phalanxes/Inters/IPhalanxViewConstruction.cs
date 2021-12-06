using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Phalanxes.Inters
{
    /// <summary>
    /// Phalanx View Construction Interface
    /// </summary>
    public interface IPhalanxViewConstruction
    {
        PhalanxCallSign GetPhalanxCallSign();

        IInsigniaReport GetInsigniaReport();
    }
}