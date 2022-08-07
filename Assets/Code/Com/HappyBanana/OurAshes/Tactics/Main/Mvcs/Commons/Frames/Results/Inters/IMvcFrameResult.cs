using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters
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