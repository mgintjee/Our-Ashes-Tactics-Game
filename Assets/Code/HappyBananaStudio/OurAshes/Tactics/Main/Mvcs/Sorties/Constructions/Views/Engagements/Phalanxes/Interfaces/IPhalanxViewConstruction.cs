using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Insignias.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Interfaces
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