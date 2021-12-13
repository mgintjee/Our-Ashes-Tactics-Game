using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Types;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Requests.Inters
{
    /// <summary>
    /// Mvc Control Splash Request Interface
    /// </summary>
    public interface IMvcControlSplashRequest : IMvcControlRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SplashRequestType GetSplashRequestType();
    }
}