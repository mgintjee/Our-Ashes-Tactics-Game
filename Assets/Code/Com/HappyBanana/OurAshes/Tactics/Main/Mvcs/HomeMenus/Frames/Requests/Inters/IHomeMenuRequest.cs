using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHomeMenuRequest
        : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        RequestType GetRequestType();
    }
}