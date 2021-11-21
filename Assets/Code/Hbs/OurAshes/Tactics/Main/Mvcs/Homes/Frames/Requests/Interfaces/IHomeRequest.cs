using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Homes.Requests.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Requests.Interfaces
{
    /// <summary>
    /// Home Request Interface
    /// </summary>
    public interface IHomeRequest : IMvcRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HomeRequestType GetHomeRequestType();
    }
}