using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Impls
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