using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Types;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Inters
{
    /// <summary>
    /// Splash Request Interface
    /// </summary>
    public interface ISplashRequest : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SplashRequestType GetSplashRequestType();
    }
}