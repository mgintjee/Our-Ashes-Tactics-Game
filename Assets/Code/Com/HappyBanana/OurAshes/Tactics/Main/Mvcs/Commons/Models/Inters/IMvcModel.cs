using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters
{
    /// <summary>
    /// Mvc Model Interface
    /// </summary>
    public interface IMvcModel
    {
        bool IsProcessing();

        IMvcModelState GetState();

        void Process(IMvcRequest mvcModelRequest);
    }
}