using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters
{
    /// <summary>
    /// Mvc Frame Result Interface
    /// </summary>
    public interface IMvcFrameResult
    {
        IMvcFrameConstruction GetNextMvcFrameConstruction();

        IMvcFrameConstruction GetCurrMvcFrameConstruction();

        IMvcFrameConstruction GetPrevMvcFrameConstruction();

        IMvcFrameState GetMvcFrameState();
    }
}