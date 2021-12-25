using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Frames.Homes.Requests.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Requests.Inters
{
    /// <summary>
    /// Home Request Interface
    /// </summary>
    public interface IMvcControlHomeRequest : IMvcModelRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HomeRequestType GetHomeRequestType();
    }
}