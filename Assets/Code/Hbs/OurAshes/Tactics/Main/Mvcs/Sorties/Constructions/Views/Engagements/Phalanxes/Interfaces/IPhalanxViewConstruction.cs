using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Interfaces
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