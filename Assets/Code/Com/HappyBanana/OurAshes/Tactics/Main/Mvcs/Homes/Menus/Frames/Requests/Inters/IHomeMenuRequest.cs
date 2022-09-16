using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Requests.Inters
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