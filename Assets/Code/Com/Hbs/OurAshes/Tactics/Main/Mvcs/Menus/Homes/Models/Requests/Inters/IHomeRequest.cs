using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Models.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Models.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IHomeRequest
        : IMvcModelRequest
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HomeRequestType GetHomeRequestType();
    }
}