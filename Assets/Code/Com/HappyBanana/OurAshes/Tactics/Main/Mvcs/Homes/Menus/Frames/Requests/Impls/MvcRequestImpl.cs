using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Requests.Types;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcRequestImpl
        : IHomeMenuRequest
    {
        // Todo
        private RequestType homeRequestType = RequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        public IHomeMenuRequest SetRequestType(RequestType homeRequestType)
        {
            this.homeRequestType = homeRequestType;
            return this;
        }

        /// <inheritdoc/>
        RequestType IHomeMenuRequest.GetRequestType()
        {
            return this.homeRequestType;
        }
    }
}