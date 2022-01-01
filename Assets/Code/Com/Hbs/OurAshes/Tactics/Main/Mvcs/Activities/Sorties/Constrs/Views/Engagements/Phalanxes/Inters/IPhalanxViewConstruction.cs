﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Phalanxes.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Views.Insignias.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Engagements.Phalanxes.Inters
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