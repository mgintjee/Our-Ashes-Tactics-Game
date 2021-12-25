﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters
{
    public interface IMvcFrameState
        : IReport
    {
        IMvcControlState GetMvcControlState();

        IMvcModelState GetMvcModelState();

        IMvcViewState GetMvcViewState();
    }
}