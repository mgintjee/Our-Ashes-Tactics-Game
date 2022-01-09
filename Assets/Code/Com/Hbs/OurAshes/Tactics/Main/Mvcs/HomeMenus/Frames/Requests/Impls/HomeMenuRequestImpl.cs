using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Types;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class HomeMenuRequestImpl
        : IHomeMenuRequest
    {
        // Todo
        private HomeRequestType homeRequestType = HomeRequestType.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="homeRequestType"></param>
        public IHomeMenuRequest SetHomeRequestType(HomeRequestType homeRequestType)
        {
            this.homeRequestType = homeRequestType;
            return this;
        }

        /// <inheritdoc/>
        HomeRequestType IHomeMenuRequest.GetHomeRequestType()
        {
            return this.homeRequestType;
        }
    }
}